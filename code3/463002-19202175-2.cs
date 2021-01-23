    using System;
    using System.Threading.Tasks;
    using System.Net;
    using System.Threading;
    
    namespace HttpListenerSpeed
    {
        class Program
        {
            static void Main(string[] args)
            {
                var listener = new Listener();
    
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
    
                listener.Shutdown();
            }
        }
    
        internal class Listener
        {
            private const int RequestDispatchThreadCount = 4;
            private readonly HttpListener _httpListener = new HttpListener();
            private readonly Thread[] _requestThreads;
            private readonly byte[] _garbage;
    
            internal Listener()
            {
                _garbage = CreateGarbage();
    
                _httpListener.Prefixes.Add("http://*:8080/");
                _httpListener.Start();
                _requestThreads = new Thread[RequestDispatchThreadCount];
                for (int i = 0; i < _requestThreads.Length; i++)
                {
                    _requestThreads[i] = new Thread(RequestDispatchThread);
                    _requestThreads[i].Start();
                }
            }
    
            private static byte[] CreateGarbage()
            {
                int[] numbers = new int[2150000];
    
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = 1000000 + i;
                }
    
                Shuffle(numbers);
    
                return System.Text.Encoding.UTF8.GetBytes(string.Join<int>(", ", numbers));
            }
    
            private static void Shuffle<T>(T[] array)
            {
                Random random = new Random();
                for (int i = array.Length; i > 1; i--)
                {
                    // Pick random element to swap.
                    int j = random.Next(i); // 0 <= j <= i-1
                    // Swap.
                    T tmp = array[j];
                    array[j] = array[i - 1];
                    array[i - 1] = tmp;
                }
            }
    
            private void RequestDispatchThread()
            {
                while (_httpListener.IsListening)
                {
                    string url = string.Empty;
    
                    try
                    {
                        // Yeah, this blocks, but that's the whole point of this thread
                        // Note: the number of threads that are dispatching requets in no way limits the number of "open" requests that we can have
                        var context = _httpListener.GetContext();
    
                        // For this demo we only support GET
                        if (context.Request.HttpMethod != "GET")
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                            context.Response.Close();
                        }
    
                        // Don't care what the URL is... you're getting a bunch of garbage, and you better like it!
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                        context.Response.ContentLength64 = _garbage.Length;
                        context.Response.OutputStream.BeginWrite(_garbage, 0, _garbage.Length, result =>
                        {
                            context.Response.OutputStream.EndWrite(result);
                            context.Response.Close();
                        }, context);
                    }
                    catch (System.Net.HttpListenerException e)
                    {
                        // Bail out - this happens on shutdown
                        return;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unexpected exception: {0}", e.Message);
                    }
                }
            }
    
            internal void Shutdown()
            {
                if (!_httpListener.IsListening)
                {
                    return;
                }
    
                // Stop the listener
                _httpListener.Stop();
    
                //  Wait for all the request threads to stop
                for (int i = 0; i < _requestThreads.Length; i++)
                {
                    var thread = _requestThreads[i];
                    if (thread != null) thread.Join();
                    _requestThreads[i] = null;
                }
            }
        }
    }
