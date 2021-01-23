            PipeStreamObservable.Create(out stream, "testpipe")
                                  .Subscribe(str =>
                                      {
                                         
                                          Console.WriteLine(str);
                                          
                                      },
                                      Console.WriteLine,
                                      Console.WriteLine);
    OR
            var formatter = new BinaryFormatter();
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            NamedPipeServerStream stream;
            
            PipeStreamObservable.Create<Hashtable>(out stream, "testpipe", formatter)
                                  .Subscribe(table =>
                                      {
                                         
                                          Console.WriteLine(table["abc"]);
                                          
                                      },
                                      Console.WriteLine,
                                      Console.WriteLine);
    
    Code:
    public static class PipeStreamObservable
    {
        private static readonly PipeSecurity PipeSecurity;
        private static readonly ILog Logger = LogManager.GetLogger("weldR");
        static PipeStreamObservable()
        {
            PipeSecurity = new PipeSecurity();
            PipeSecurity.AddAccessRule(
                new PipeAccessRule(WindowsIdentity.GetCurrent().User, PipeAccessRights.FullControl, AccessControlType.Allow)
            );
            PipeSecurity.AddAccessRule(
                new PipeAccessRule(
                    new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null), PipeAccessRights.ReadWrite, AccessControlType.Allow
                )
            );
        }
        public static void Write<T>(this NamedPipeClientStream stream, T type, IFormatter formatter) where T : ISerializable
        {
            formatter.Serialize(stream, type);
        }
        public static void Write<T>(this NamedPipeServerStream stream, T type, IFormatter formatter) where T : ISerializable
        {
            formatter.Serialize(stream, type);
        }
        public static int Write(this NamedPipeClientStream stream, string str)
        {
            var buffer = Encoding.Unicode.GetBytes(str);
            var len = buffer.Length;
            if (len > UInt16.MaxValue)
            {
                len = (int)UInt16.MaxValue;
            }
            stream.WriteByte((byte)(len / 256));
            stream.WriteByte((byte)(len & 255));
            stream.Write(buffer, 0, len);
            stream.Flush();
            return buffer.Length + 2;
        }
        public static int Write(this NamedPipeServerStream stream, string str)
        {
            var buffer = Encoding.Unicode.GetBytes(str);
            var len = buffer.Length;
            if (len > UInt16.MaxValue)
            {
                len = (int)UInt16.MaxValue;
            }
            stream.WriteByte((byte)(len / 256));
            stream.WriteByte((byte)(len & 255));
            stream.Write(buffer, 0, len);
            stream.Flush();
            return buffer.Length + 2;
        }
        public static IObservable<T> Create<T>(out NamedPipeServerStream stream, string pipeName, IFormatter formatter)
        {
            stream = new NamedPipeServerStream(pipeName, PipeDirection.InOut,
                1, PipeTransmissionMode.Byte,
                PipeOptions.Asynchronous);
            var serverStream = stream;
            return Observable.Create<T>(o =>
            {
                var currentStateSubscription = new SerialDisposable();
                return NewThreadScheduler.Default.Schedule(
                    new FormatterIterator<T>(serverStream, formatter), (state, self) =>
                        currentStateSubscription.Disposable = state.ReadNext()
                            .Subscribe(str =>
                            {
                                self(state);
                                o.OnNext(str);
                            },
                            o.OnError,
                            () =>
                            {
                                currentStateSubscription.Dispose();
                                o.OnCompleted();
                            })
                    );
            });
        }
        public static IObservable<string> Create(out NamedPipeServerStream stream, string pipeName)
        {
            stream = new NamedPipeServerStream(pipeName, PipeDirection.InOut,
                1, PipeTransmissionMode.Byte,
                PipeOptions.Asynchronous);
            var serverStream = stream;
            return Observable.Create<string>(o =>
            {
                var currentStateSubscription = new SerialDisposable();
                return NewThreadScheduler.Default.Schedule(
                    new StringIterator(serverStream), (state, self) =>
                        currentStateSubscription.Disposable = state.ReadNext()
                            .Subscribe(str =>
                            {
                                self(state);
                                o.OnNext(str);
                            },
                            o.OnError,
                            () =>
                                {
                                    currentStateSubscription.Dispose();
                                    o.OnCompleted();
                                })
                    );
            });
        }
        public static IObservable<string> Create(out NamedPipeClientStream stream, string server, string pipeName)
        {
            stream = new NamedPipeClientStream(server, pipeName, PipeDirection.InOut,
                PipeOptions.Asynchronous);
            var serverStream = stream;
            return Observable.Create<string>(o =>
            {
                var currentStateSubscription = new SerialDisposable();
                return NewThreadScheduler.Default.Schedule(
                    new StringIterator(serverStream), (state, self) =>
                        currentStateSubscription.Disposable = state.ReadNext()
                            .Subscribe(str =>
                            {
                                self(state);
                                o.OnNext(str);
                            },
                            o.OnError,
                            () =>
                            {
                                currentStateSubscription.Dispose();
                                o.OnCompleted();
                            })
                    );
            });
        }
        public static IObservable<T> Create<T>(out NamedPipeClientStream stream, 
            string server, 
            string pipeName, 
            IFormatter formatter)
        {
            stream = new NamedPipeClientStream(server, pipeName, PipeDirection.InOut,
                PipeOptions.Asynchronous);
            var serverStream = stream;
            return Observable.Create<T>(o =>
            {
                var currentStateSubscription = new SerialDisposable();
           
                return NewThreadScheduler.Default.Schedule(
                    new FormatterIterator<T>(serverStream, formatter), (state, self) =>
                        currentStateSubscription.Disposable = state.ReadNext()
                            .Subscribe(str =>
                                {
                                    self(state);
                                    o.OnNext(str);
                                },
                                o.OnError,
                                () =>
                                    {
                                        currentStateSubscription.Dispose();
                                        o.OnCompleted();
                                    })
                    );
            });
        }
        private delegate bool StreamHandler<T>(Stream input, out T output);
        public interface IIterator<out T>
        {
            IObservable<T> ReadNext();
        }
        private abstract class ReaderState<T> : IIterator<T>
        {
            public abstract IObservable<T> ReadNext();
        }
        private class ReadReadyState<T> : ReaderState<T>
        {
            private readonly Stream _stream;
            private readonly StreamHandler<T> _handler;
            internal ReadReadyState(Stream stream, StreamHandler<T> handler)
            {
                _stream = stream;
                _handler = handler;
            }
            public override IObservable<T> ReadNext()
            {
                return Observable.Create<T>(o =>
                {
                    try
                    {
                        T value;
                        if (_handler(_stream, out value))
                            o.OnNext(value);
                    }
                    catch (SerializationException e)
                    {
                        Logger.Debug(e);
                        o.OnCompleted();
                    }
                    catch (Exception e)
                    {
                        Logger.Debug(e);
                        o.OnError(e);
                        return _stream;
                    }
                    return Disposable.Empty;
                });
            }
        }
        private class ServerStreamReader<T> : IIterator<T>
        {
            private ReaderState<T> _currentState;
            private readonly NamedPipeServerStream _stream;
            private readonly StreamHandler<T> _handler; 
            internal ServerStreamReader(NamedPipeServerStream stream, StreamHandler<T> handler)
            {
                _stream = stream;
                _handler = handler;
                _currentState = new ConnectionWaitState<T>(this);
            }
            private class ConnectionWaitState<T1> : ReaderState<T1>
            {
                private readonly ServerStreamReader<T1> _parent;
  
                internal ConnectionWaitState(ServerStreamReader<T1> parent)
                {
                    _parent = parent;
                }
                public override IObservable<T1> ReadNext()
                {
                    try
                    {
                        _parent._stream.WaitForConnection();
                    }
                    catch (IOException)
                    {
                        
                    }
                    _parent._currentState = new ReadReadyState<T1>(_parent._stream, _parent._handler);
                    return _parent._currentState.ReadNext();
                }
            }
            public IObservable<T> ReadNext()
            {
                return _currentState.ReadNext();
            }
        }
        private class ClientStreamReader<T> : IIterator<T>
        {
            private ReaderState<T> _currentState;
            private readonly NamedPipeClientStream _stream;
            private readonly StreamHandler<T> _handler;
            internal ClientStreamReader(NamedPipeClientStream stream, StreamHandler<T> handler)
            {
                _stream = stream;
                _handler = handler;
                _currentState = new ConnectionWaitState<T>(this);
            }
            private class ConnectionWaitState<T1> : ReaderState<T1>
            {
                private readonly ClientStreamReader<T1> _parent;
                internal ConnectionWaitState(ClientStreamReader<T1> parent)
                {
                    _parent = parent;
                }
                public override IObservable<T1> ReadNext()
                {
                    try
                    {
                        _parent._stream.Connect();
                    }
                    catch (IOException)
                    {
                        
                    }
                    _parent._currentState = new ReadReadyState<T1>(_parent._stream, _parent._handler);
                    return _parent._currentState.ReadNext();
                }
            }
            public IObservable<T> ReadNext()
            {
                return _currentState.ReadNext();
            }
        }
        private sealed class FormatterIterator<T> : IIterator<T>
        {
            private readonly IIterator<T> _iterator;
            private readonly IFormatter _formatter;
            
            public FormatterIterator(NamedPipeServerStream source, IFormatter formatter)
            {
                _iterator = new ServerStreamReader<T>(source, DeserializeWithFormatter);
                _formatter = formatter;
            }
            public FormatterIterator(NamedPipeClientStream source, IFormatter formatter)
            {
                _iterator = new ClientStreamReader<T>(source, DeserializeWithFormatter);
                _formatter = formatter;
            }
            public IObservable<T> ReadNext()
            {
                return _iterator.ReadNext();
            }
            private bool DeserializeWithFormatter(Stream stream, out T value)
            {
                try
                {
                    value = (T) _formatter.Deserialize(stream);
                    return true;
                }
                catch (SerializationException)
                {
                    value = default(T);
                    return false;
                }
            }
        }
        private sealed class StringIterator : IIterator<string>
        {
            private readonly IIterator<string> _iterator;
            private static bool DeserializeToString(Stream stream, out string value)
            {
                var len = stream.ReadByte();
                if (len < 0)
                {
                    value = null;
                    return false;
                }
                len *= 256;
                len += stream.ReadByte();
                var buffer = new byte[len];
                stream.Read(buffer, 0, len);
                value = Encoding.Unicode.GetString(buffer);
                return true;
            }
            public StringIterator(NamedPipeServerStream source)
            {
                _iterator = new ServerStreamReader<string>(source, DeserializeToString);
            }
             public StringIterator(NamedPipeClientStream source)
            {
                _iterator = new ClientStreamReader<string>(source, DeserializeToString);
            }
            public IObservable<string> ReadNext()
            {
                return _iterator.ReadNext();
            }
        }
    }
