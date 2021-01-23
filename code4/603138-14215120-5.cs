    public bool EvaluateNode( Node node )
    {
        var qualificationNode = node as QualificationNode;
        if ( qualificationNode != null )
        {
            return qualificationNode.IsQualificationMet;
        }
        var operatorNode = node as OperatorNode;
        if ( operatorNode.IsAnd )
        {
            return EvaluateNode( node.LeftChild ) && EvaluateNode( node.RightChild );
        }
        return EvaluateNode( node.LeftChild ) || EvaluateNode( node.RightChild );
    }
