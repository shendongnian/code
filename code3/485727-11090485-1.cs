    [JsonProperty(PropertyName = "metadata")]
    public Metadata Metadata
    {
        get
        {
            return new Metadata() {NodeType = NodeType, TypeDepth = TypeDepth};
        }
        set { 
              TypeDepth = value.TypeDepth;
               NodeType = value.NodeType;
        }
    }
?
