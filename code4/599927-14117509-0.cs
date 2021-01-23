    /// <summary>
    /// Friendship relationship - User is a friend of a User with a Status of REQUESTED, ACCEPTED, DENIED, BLOCKED
    /// </summary>
    public class Friend : Relationship<FriendPayload>, IRelationshipAllowingSourceNode<User>,
        IRelationshipAllowingTargetNode<User>
    {
        public static readonly string TypeKey = "FRIEND";
    
        public Friend(NodeReference targetNode)
            : base(targetNode)
        { }
    
        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
