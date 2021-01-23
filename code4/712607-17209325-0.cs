    class GraphRelationshipEntityInstanceToSetEntity<T, T1> : Relationship, IRelationshipAllowingSourceNode<T>, IRelationshipAllowingTargetNode<T1>
        {
            string RelationshipName;
    
            public GraphRelationshipEntityInstanceToSetEntity(NodeReference targetNode)
                : base(targetNode)
            {
    
            }
    
            public GraphRelationshipEntityInstanceToSetEntity(string RelationshipName, NodeReference targetNode)
                : base(targetNode)
            {
                this.RelationshipName = RelationshipName;
            }
    
            public override string RelationshipTypeKey
            {
                get { return RelationshipName; }
            }
        }
