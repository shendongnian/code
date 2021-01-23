    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace NodesEditor
    {
        public static class NodesDataSource
        {
            public static Random random = new Random();
    
            public static Node GetRandomNode()
            {
                return new Node
                    {
                        X = random.Next(0,500),
                        Y = random.Next(0,500)
                    };
                
            }
    
            public static IEnumerable<Node> GetRandomNodes()
            {
                return Enumerable.Range(5, random.Next(6, 10)).Select(x => GetRandomNode());
            }
    
            public static Connector GetRandomConnector(IEnumerable<Node> nodes)
            {
                return new Connector { Start = nodes.FirstOrDefault(), End = nodes.Skip(1).FirstOrDefault() };
            }
    
            public static IEnumerable<Connector> GetRandomConnectors(List<Node> nodes)
            {
                var result = new List<Connector>();
                for (int i = 0; i < nodes.Count() - 1; i++)
                {
                    result.Add(new Connector() {Start = nodes[i], End = nodes[i + 1]});
                }
                return result;
            }
        }
    }
