    abstract class Command : IBinarySerializable
    {
        
    }
    class SomeCommand : Command
    {
        public int Arg1 { get; set; }
        
        public void Serialize(BinaryWriter toStream)
        {
            toStream.Write(Arg1);
        }
        public void Deserialize(BinaryReader fromStream)
        {
            Arg1 = fromStream.ReadInt32();
        }
    }
