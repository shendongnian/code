        public static List<Dictionary<string, object>> BuildTree(int? parentNodeID = null, List<Node> exampleData = null)
        {
            // kickstart the recursion with example data
            if (exampleData == null)
            {
                exampleData = new List<Node>();
                exampleData.Add(new Node(null, 1, "Country"));
                exampleData.Add(new Node(null, 2, "Year"));
                exampleData.Add(new Node(1, 3, "President"));
                exampleData.Add(new Node(1, 4, "Population"));
                exampleData.Add(new Node(1, 5, "State"));
                exampleData.Add(new Node(5, 6, "Governor"));
                exampleData.Add(new Node(5, 7, "Population"));
                exampleData.Add(new Node(5, 8, "County"));
                exampleData.Add(new Node(8, 9, "Population"));
            }
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
            var nodes = exampleData.Where(a => a.ParentNodeID == parentNodeID).ToList();
            if (nodes != null)
            {
                Func<Node, Dictionary<string, object>> getNodeDictionary = n => {
                    var children = BuildTree(n.NodeID, exampleData);
                    var returnDictionary = new Dictionary<string, object> {
                        { "NodeID", n.NodeID},
                        { "NodeText", n.NodeText }
                    };
                    if (children.Any())
                    {
                        returnDictionary.Add("Children", children);
                    }
                    return returnDictionary;
                };
                // No need for where clause since we now do not add the empty elements
                result.AddRange(nodes
                    .Select(a => getNodeDictionary(a))
                    .ToList()
                );
            }
           
            return result;
        }
