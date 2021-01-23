    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    
    namespace MultiThreadedTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Test both ways of executing IAsyncResult web calls
    
                ExecuteUsingWaitHandles();
                Console.WriteLine();
    
                ExecuteUsingThreadStart();
                Console.ReadKey();
            }
    
            private static void ExecuteUsingWaitHandles()
            {
                Console.WriteLine("Starting to execute using wait handles (old way) ");
    
                WS2SoapClient ws2 = new WS2SoapClient();
                WS3SoapClient ws3 = new WS3SoapClient();
    
                IAsyncResult result1 = null;
                IAsyncResult result2 = null;
    
                // Time the threadas
                var stopWatchBoth = System.Diagnostics.Stopwatch.StartNew();
                result1 = ws3.BeginOP31();
                result2 = ws2.BeginOP21();
                WaitHandle[] handles = { result1.AsyncWaitHandle, result2.AsyncWaitHandle };
                WaitHandle.WaitAll(handles);
    
                stopWatchBoth.Stop();
    
                // Display execution time of individual calls
                Console.WriteLine((result1.AsyncState as StateObject));
                Console.WriteLine((result2.AsyncState as StateObject));
    
                // Display time for both calls together
                Console.WriteLine("Asynchronous Execution Time for both is {0}", stopWatchBoth.Elapsed.TotalSeconds);
            }
    
            private static void ExecuteUsingThreadStart()
            {
                Console.WriteLine("Starting to execute using thread start (new way) ");
    
                WS2SoapClient ws2 = new WS2SoapClient();
                WS3SoapClient ws3 = new WS3SoapClient();
    
                IAsyncResult result1 = null;
                IAsyncResult result2 = null;
    
                // Create threads to execute the methods asynchronously
                Thread startOp3 = new Thread( () => result1 = ws3.BeginOP31() );
                Thread startOp2 = new Thread( () => result2 = ws2.BeginOP21() );
    
                // Time the threadas
                var stopWatchBoth = System.Diagnostics.Stopwatch.StartNew();
    
                // Start the threads
                startOp2.Start();
                startOp3.Start();
    
                // Make this thread wait until both of those threads are complete
                startOp2.Join();
                startOp3.Join();
    
                stopWatchBoth.Stop();
    
                // Display execution time of individual calls
                Console.WriteLine((result1.AsyncState as StateObject));
                Console.WriteLine((result2.AsyncState as StateObject));
    
                // Display time for both calls together
                Console.WriteLine("Asynchronous Execution Time for both is {0}", stopWatchBoth.Elapsed.TotalSeconds);
            }
        }
    
        // Class representing your WS2 client
        internal class WS2SoapClient : TestWebRequestAsyncBase
        {
            public WS2SoapClient() : base("http://www.msn.com/") { }
    
            public IAsyncResult BeginOP21()
            {
                Thread.Sleep(TimeSpan.FromSeconds(10D));
                return BeginWebRequest();
            }
        }
    
        // Class representing your WS3 client
        internal class WS3SoapClient : TestWebRequestAsyncBase
        {
            public WS3SoapClient() : base("http://www.google.com/") { }
    
            public IAsyncResult BeginOP31()
            {
                // Added sleep here to simulate a much longer request, which should make it obvious if the times are overlapping or sequential
                Thread.Sleep(TimeSpan.FromSeconds(20D)); 
                return BeginWebRequest();
            }
        }
    
        // Base class that makes the web request
        internal abstract class TestWebRequestAsyncBase
        {
            public StateObject AsyncStateObject;
            protected string UriToCall;
    
            public TestWebRequestAsyncBase(string uri)
            {
                AsyncStateObject = new StateObject()
                {
                    UriToCall = uri
                };
    
                this.UriToCall = uri;
            }
    
            protected IAsyncResult BeginWebRequest()
            {
                WebRequest request =
                   WebRequest.Create(this.UriToCall);
    
                AsyncCallback callBack = new AsyncCallback(onCompleted);
    
                AsyncStateObject.WebRequest = request;
                AsyncStateObject.Stopwatch = System.Diagnostics.Stopwatch.StartNew();
            
                return request.BeginGetResponse(callBack, AsyncStateObject);
            }
    
            void onCompleted(IAsyncResult result)
            {
                this.AsyncStateObject = (StateObject)result.AsyncState;
                this.AsyncStateObject.Stopwatch.Stop();
    
                var webResponse = this.AsyncStateObject.WebRequest.EndGetResponse(result);
                Console.WriteLine(webResponse.ContentType, webResponse.ResponseUri);
            }
        }
    
        // Keep stopwatch on state object for illustration of individual execution time
        internal class StateObject
        {
            public System.Diagnostics.Stopwatch Stopwatch { get; set; }
            public WebRequest WebRequest { get; set; }
            public string UriToCall;
    
            public override string ToString()
            {
                return string.Format("Request to {0} executed in {1} seconds", this.UriToCall, Stopwatch.Elapsed.TotalSeconds);
            }
        }
    }
