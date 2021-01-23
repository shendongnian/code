    public static class PipeStreamObservable
    {
        private static readonly PipeSecurity PipeSecurity; 
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
        public static IObservable<T> Create<T>(out NamedPipeServerStream stream, string pipeName, IFormatter formatter)
        {
            stream = new NamedPipeServerStream(pipeName, PipeDirection.InOut,
                1, PipeTransmissionMode.Byte,
                PipeOptions.Asynchronous);
            stream.WaitForConnection();
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
            stream.WaitForConnection();
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
            stream.Connect();
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
            stream.Connect();
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
        public interface IIterator<out T>
        {
            IObservable<T> ReadNext();
        }
        private sealed class FormatterIterator<T> : IIterator<T>
        {
            private readonly Stream _stream;
            private readonly IFormatter _formatter;
            public FormatterIterator(Stream source, IFormatter formatter)
            {
                _stream = source;
                _formatter = formatter;
            }
            public IObservable<T> ReadNext()
            {
                return Observable.Create<T>(o =>
                {
                    try
                    {
                        var a = (T) _formatter.Deserialize(_stream);
                        o.OnNext(a);  
                    }
                    catch (SerializationException)
                    {
                        o.OnCompleted();
                    }
                    catch (Exception e)
                    {
                        o.OnError(e);
                    }
                    return Disposable.Empty;
                });
            }
        }
        private sealed class StringIterator : IIterator<string>
        {
            private readonly Stream _stream;
            public StringIterator(Stream source)
            {
                _stream = source;
            }
            public IObservable<string> ReadNext()
            {
                return Observable.Create<string>(o =>
                {
                    try
                    {
                        var len = _stream.ReadByte();
                        if (len < 0)
                        {
                            o.OnCompleted();
                            return _stream;
                        }
                        len *= 256;
                        len += _stream.ReadByte();
                        var buffer = new byte[len];
                        _stream.Read(buffer, 0, len);
                        var result = Encoding.Unicode.GetString(buffer);
                        o.OnNext(result);
                        return Disposable.Empty;
                    }
                    catch (Exception e)
                    {
                        o.OnError(e);
                        return _stream;
                    }
                });
            }
        }
    }
