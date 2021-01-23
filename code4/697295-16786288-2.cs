    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    using FluentAssertions;
    namespace StackOverflow
    {
        public class Class1
        {
            //Populating data
            Dictionary<int, List<string>> GroupedA = new Dictionary<int, List<string>>();
            public Class1()
            {
                GroupedA.Add(1, new List<string> { "1", "2", "3" });
                GroupedA.Add(2, new List<string> { "1", "32", "3", "4" });
                GroupedA.Add(3, new List<string> { "1", "52", "43", "4" });
            }
            [Fact]
            public void ToDictionarySpec()
            {
                var data = GroupedA.Select(v => Tuple.Create(v.Key, v.Value));
                var r = data.SelectMany(tuple => tuple.Item2.Select(u => new { U = u, T = tuple.Item1 }))
                .GroupBy(x => x.U)
                .ToDictionary(g => g.Key, g => g.Select(x => x.T).ToList());
                //Printing data 
                var pairs = r.Select(pair => string.Format("{0} : {1}", pair.Key, string.Join(",", pair.Value)));
                Console.WriteLine(string.Join(Environment.NewLine, pairs));
            }
        }
    }
