        List<double[]> _nestedArray ; // The nested array I would like to serialize.
        [ProtoMember(1)] 
        private List<ProtobufArray<double>> _nestedArrayForProtoBuf // Never used elsewhere
        {
            get 
            {
                if (_nestedArray == null)  //  ( _nestedArray == null || _nestedArray.Count == 0 )  if the default constructor instanciate it
                    return null;
                return _nestedArray.Select(p => new ProtobufArray<double>(p)).ToList();
            }
            set 
            {
                _nestedArray = value.Select(p => p.MyArray).ToList();
            }
        }
    [ProtoContract]
    public class ProtobufArray<T>   // The intermediate type
    {
        [ProtoMember(1)]
        public T[] MyArray;
        public ProtobufArray()
        { }
        public ProtobufArray(T[] array)
        {
            MyArray = array;
        }
    }
