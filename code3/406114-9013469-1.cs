    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.ServiceModel.Web;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static int Main(string[] args)
            {
                var failList = new ConcurrentDictionary<MethodInfo, ISet<String>>();
                var assembliesToRunOn = (args.Length == 0 ? new[] {Assembly.GetExecutingAssembly()} : args.Select(Assembly.LoadFrom)).ToList();
                assembliesToRunOn.AsParallel().ForAll(
                    a => Array.ForEach(a.GetTypes(), t => Array.ForEach(t.GetMethods(BindingFlags.Public | BindingFlags.Instance),
                        mi =>
                            {
                                var miParams = mi.GetParameters();
                                var attribs = mi.GetCustomAttributes(typeof (WebGetAttribute), true);
                                if (attribs.Length <= 0) return;
                                var wga = (WebGetAttribute)attribs[0];
                                wga.UriTemplate
                                    .Split('/')
                                    .ToList()
                                    .ForEach(tp =>
                                                 {
                                                     if (tp.StartsWith("{") && tp.EndsWith("}"))
                                                     {
                                                         var tpName = tp.Substring(1, tp.Length - 2);
                                                         if (!miParams.Any(pi => pi.Name == tpName))
                                                         {
                                                             failList.AddOrUpdate(mi, new HashSet<string> {tpName}, (miv, l) =>
                                                                                                                        {
                                                                                                                            l.Add(tpName);
                                                                                                                            return l;
                                                                                                                        });
                                                         }
                                                     }
                                                 });
                            })));
                if (failList.Count == 0) return 0;
                failList.ToList().ForEach(kvp => Console.Out.WriteLine("Method " + kvp.Key + " in type " + kvp.Key.DeclaringType + " is missing the following expected parameters: " + String.Join(", ", kvp.Value.ToArray())));
                return failList.Count;
            }
    
            [WebGet(UriTemplate = "Endpoint/{param1}/{param2}")]
            public void WillPass(String param1, String param2) { }
    
            [WebGet(UriTemplate = "Endpoint/{param1}/{param2}")]
            public void WillFail() { }
    
            [WebGet(UriTemplate = "Endpoint/{param1}/{param2}")]
            public void WillFail2(String param1) { }
        }
    }
