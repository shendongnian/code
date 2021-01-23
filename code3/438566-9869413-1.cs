    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Json;
    using System.Threading;
    
    namespace MyAsync
    {
        class Program
        {
            static void Main(string[] args)
            {
                var cts = new CancellationTokenSource();
                Console.WriteLine("Start Main");
                List<Task<List<MyObject>>> listoftasks = new List<Task<List<MyObject>>>();
                listoftasks.Add(GetGoogle(cts));
                listoftasks.Add(GetTwitter(cts));
                listoftasks.Add(GetSleep(cts));
                listoftasks.Add(GetxSleep(cts));
                
                List<MyObject>[] arrayofanswers = Task.WhenAll(listoftasks).Result;
                List<MyObject> answer = new List<MyObject>();
                foreach (List<MyObject> answers in arrayofanswers)
                {
                    answer.AddRange(answers);
                }
                foreach (MyObject o in answer)
                {
                    Console.WriteLine("{0} - {1}", o.name, o.origin);
                }
                Console.WriteLine("Press <Enter>");
                Console.ReadLine();
            } 
         
            static async Task<List<MyObject>> GetGoogle(CancellationTokenSource cts) 
            {
                try
                {
                    Console.WriteLine("Start GetGoogle");
                    List<MyObject> l = new List<MyObject>();
                    var client = new HttpClient();
                    Task<HttpResponseMessage> awaitable = client.GetAsync("http://ajax.googleapis.com/ajax/services/search/web?v=1.0&q=broersa", cts.Token);
                    HttpResponseMessage res = await awaitable;
                    Console.WriteLine("After GetGoogle GetAsync");
                    dynamic data = JsonValue.Parse(res.Content.ReadAsStringAsync().Result);
                    Console.WriteLine("After GetGoogle ReadAsStringAsync");
                    foreach (var r in data.responseData.results)
                    {
                        l.Add(new MyObject() { name = r.titleNoFormatting, origin = "google" });
                    }
                    return l;
                }
                catch (TaskCanceledException)
                {
                    return new List<MyObject>();
                }
            }
    
            static async Task<List<MyObject>> GetTwitter(CancellationTokenSource cts)
            {
                try
                {
                    Console.WriteLine("Start GetTwitter");
                    List<MyObject> l = new List<MyObject>();
                    var client = new HttpClient();
                    Task<HttpResponseMessage> awaitable = client.GetAsync("http://search.twitter.com/search.json?q=broersa&rpp=5&include_entities=true&result_type=mixed",cts.Token);
                    HttpResponseMessage res = await awaitable;
                    Console.WriteLine("After GetTwitter GetAsync");
                    dynamic data = JsonValue.Parse(res.Content.ReadAsStringAsync().Result);
                    Console.WriteLine("After GetTwitter ReadAsStringAsync");
                    foreach (var r in data.results)
                    {
                        l.Add(new MyObject() { name = r.text, origin = "twitter" });
                    }
                    return l;
                }
                catch (TaskCanceledException)
                {
                    return new List<MyObject>();
                }
            }
    
            static async Task<List<MyObject>> GetSleep(CancellationTokenSource cts)
            {
                try
                {
                    Console.WriteLine("Start GetSleep");
                    List<MyObject> l = new List<MyObject>();
                    await Task.Delay(5000,cts.Token);
                    l.Add(new MyObject() { name = "Slept well", origin = "sleep" });
                    return l;
                }
                catch (TaskCanceledException)
                {
                    return new List<MyObject>();
                }
    
            } 
    
            static async Task<List<MyObject>> GetxSleep(CancellationTokenSource cts)
            {
                Console.WriteLine("Start GetxSleep");
                List<MyObject> l = new List<MyObject>();
                await Task.Delay(2000);
                cts.Cancel();
                l.Add(new MyObject() { name = "Slept short", origin = "xsleep" });
                return l;
            } 
    
        }
    }
