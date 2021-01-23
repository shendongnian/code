    [DataContract]
    public class FancyNode : Node
    {
        private float rotation;
        [DataMember]
        public override float Rotation { get { return rotation; } set { rotation = value; } }
    }
