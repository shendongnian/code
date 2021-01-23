            List<MasterNode> list = new List<MasterNode>
            {
                new MasterNode
                {
                    Value="A", 
                    ChildNodes = new List<ChildNode>
                    {
                        new ChildNode{Value = "D"},
                        new ChildNode{Value = "E"},
                        new ChildNode{Value = "F"}
                    }
                },
                new MasterNode
                {
                    Value="B", 
                    ChildNodes = new List<ChildNode>
                    {                        
                        new ChildNode{Value = "G"}
                    }
                },
                new MasterNode
                {
                    Value="C", 
                    ChildNodes = new List<ChildNode>
                    {
                        new ChildNode{Value = "H"},
                        new ChildNode{Value = "I"}
                    }
                }
            };
            foreach (ChildNode c in list.SelectMany(l =>
                                    {
                                       List<ChildNode> result = l.ChildNodes.ToList();
                                       result.Insert(0, l);
                                       return result;
                                    }))
            {
                Console.WriteLine(c.Value);
            }
