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
                WS2SoapClient ws2 = new WS2SoapClient();
                WS3SoapClient ws3 = new WS3SoapClient();
    
                //capture time
                DateTime now = DateTime.Now;
                //make calls
    
                IAsyncResult result1 = null; 
                IAsyncResult result2 = null;
    
                Thread startOp3 = new Thread(
                    () => {
                        result1 = ws3.BeginOP31(); 
                    }
                );
                
                Thread startOp2 = new Thread(
                    () => {
                        result2 = ws2.BeginOP21(); 
                    }
                );
    
                startOp2.Start();
                startOp3.Start();
    
                startOp2.Join();
                startOp3.Join();
    
    
                //calculate time difference
                TimeSpan ts = DateTime.Now.Subtract(now);
                Console.WriteLine((result1.AsyncState as StateObject));
                Console.WriteLine((result2.AsyncState as StateObject));
    
                Console.WriteLine(
                    "Asynchronous Execution Time (h:m:s:ms): " + 
                        String.Format("{0}:{1}:{2}:{3}",
                            ts.Hours,
                            ts.Minutes,
                            ts.Seconds,
                            ts.Milliseconds
                        )
                    );
    
                Console.ReadKey();
            }
        }
    
        // Represents your web soap client 2
        internal class WS2SoapClient : TestWebRequestAsyncBase
        {
            public WS2SoapClient() : base("http://bing.com") { }
    
            public IAsyncResult BeginOP21()
            {
                return BeginWebRequest();
            }
        }
    
        // Represents your web soap client 3
        internal class WS3SoapClient : TestWebRequestAsyncBase
        {
            public WS3SoapClient() : base("http://google.com") { }
    
            public IAsyncResult BeginOP31()
            {
                return BeginWebRequest();
            }
        }
    
        // I just created a quick base class instead of copying code, I hate copying code
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
                   WebRequest.Create(UriToCall);
    
                AsyncCallback callBack = new AsyncCallback(onCompleted);
    
                AsyncStateObject.Stopwatch = System.Diagnostics.Stopwatch.StartNew();
            
                return request.BeginGetResponse(callBack, AsyncStateObject);
            }
    
            void onCompleted(IAsyncResult result)
            {
                this.AsyncStateObject = (StateObject)result.AsyncState;
                this.AsyncStateObject.Stopwatch.Stop();
            }
        }
    
        // Store the stopwatch to time individual execution of each request in the state object for illustration purposes
        internal class StateObject
        {
            public System.Diagnostics.Stopwatch Stopwatch { get; set; }
    
            public string UriToCall;
    
            public override string ToString()
            {
                return string.Format("Request to {0} executed in {1} seconds", this.UriToCall, Stopwatch.Elapsed.TotalSeconds);
            }
        }
    }
