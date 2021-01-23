    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Text;
    using CsQuery;
    class Program
    {
        static void Main(string[] args)
        {
            var stringBuilder = new StringBuilder();
            var url = "http://24.173.220.131/carter/currentinmates.aspx";
            CQ.CreateFromUrlAsync(url)
               .Then(response =>
               {
                   var dom = response.Dom;
                   var trs = dom.Select("#dgrdLandRecords tr").Elements;
                   foreach (var row in trs)
                   {
                       stringBuilder.AppendLine();
                       var tds = row.ChildElements.ToList();
                       for (int i = 1; i < tds.Count; i++)
                       {
                           stringBuilder.Append(tds[i].Cq().Text());
                           stringBuilder.Append("|");
                       }
                   }
                   var result = stringBuilder.ToString();
                   Console.Write(result);
               });
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
