    public IEnumerable<IContent> BuildContentFrom(IEnumerable<Node> nodes) {
         if(!nodes.Any()) return Enumerable.Empty<IContent>();
         var acc = new List<IContent>();
         BuildContentFrom(nodes);
    }
    public IEnumerable<IContent> BuildContentFrom(IEnumerable<Node> nodes, 
                                                  IList<IContent> acc) {
         foreach(var node in nodes){
             acc.Add(BuildContentFromSingle(node));
             if(node.children.Any()) BuildContentFrom(node.children, acc);
         }
    }
