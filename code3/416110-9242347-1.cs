    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Net;
    using System.Text;
    using System.Web.Script.Serialization;
    
    class Program
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                var values = new NameValueCollection
                {
                    { "q[]", "25062638" },
                    { "q[]", "search" },
                    { "q[]", "aa" },
                };
                var result = client.UploadValues("http://tinysong.com?s=sh", values);
                var json = Encoding.UTF8.GetString(result);
                var serializer = new JavaScriptSerializer();
                var obj = (IDictionary<string, object>)serializer.DeserializeObject(json);
                // there's also obj["html"] in the returned JSON
                Console.WriteLine(obj["message"]);
                
                // TODO: we have fetched the HTML, now you could scrape it in order to
                // extract the information you are interested in. You could use
                // an Html parser such as Html Agility Pack for this task:
                // http://htmlagilitypack.codeplex.com/
            }
        }
    }
