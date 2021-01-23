    IEnumerable<Node> nodes = Enumerable.Range(0, 1024)
                                        .Select(i => new Node(i.ToString));
                          
    IList<Node> nodes = Enumerable.Range(0, 1024)
                                  .Select(i => new Node(i.ToString))
                                  .ToList();
