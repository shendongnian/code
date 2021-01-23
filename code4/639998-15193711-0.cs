    using System;
    using System.Net;
    namespace CustomWebRequest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var success = WebRequest.RegisterPrefix("http://", new CustomRequestCreator());
                Console.Write("Handler registered:{0}", success);
    
                var request = WebRequest.Create(new Uri("http://home.com"));
            }
    
            class CustomRequestCreator : IWebRequestCreate
            {
                public WebRequest Create(Uri uri)
                {
                    Console.WriteLine("Custom creator");
                    return null; // return your mock here...
                }
            }
        }
    }
