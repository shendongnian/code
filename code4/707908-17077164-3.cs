    class Conf : ModelBase
    {
        NodeType _nodeType = NodeType.Type1;
    
        public NodeType NodeType
        {
            get { return _nodeType; }
            set { Set(ref _nodeType, value); }
        }
    }
