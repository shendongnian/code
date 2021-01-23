    class TypeCheckVisitor : Visitor {
       // Field used to save resulting type of a visit
       Type resultType;
       void visit( Root rootNode )
       {
          rootNode.getChild(0).accept( this );
       }
       void visit( Op opNode )
       {
          opNode.getChild(0).accept( this );
          Type type1 = resultType;
          opNode.getChild(1).accept( this );
          Type type2 = resultType;
          // Type check
          if( !type1.isCompatible( type2 ) ){
             // Produce type error
          }
          // Saves the return type of this OP (ex. Int + Int would return Int)
          resultType = typeTableLookup( opNode.getOperator(), type1, type2 );
       }
       void visit( Number number )
       {
          // Saves the type of this number as result
          resultType = number.getType();
       }
    }
