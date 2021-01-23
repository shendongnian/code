    class Root : VisitableNode {
       [...]
       void accept( Visitor v ) {
          v.visit(this);
       }
    }
    class Op : VisitableNode {
       [...]
       void accept( Visitor v ) {
          v.visit(this);
       }
    }
    class Number : VisitableNode {
       [...]
       void accept( Visitor v ) {
          v.visit(this);
       }
    }
