    public IEnumerable<IContent> BuildContentFrom(IEnumerable<Node> nodes) {
         foreach(var node in nodes){
             yield node;
             foreach(var c in BuildContentFrom(node.children)){
                 yield c;
             }
         }
    }
