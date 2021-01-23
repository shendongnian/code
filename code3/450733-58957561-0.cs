    [Serializable]
    public struct MySerializableStruct
    {
        [NonSerialized]
        public string hiddenField;
        public string normalField;
    }
