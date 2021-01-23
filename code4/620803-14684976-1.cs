    [DataContract(Name = "Configurations", Namespace = "")]
    public class Configurations : Collection<Configuration>
    {
        internal void SerializeToBinaryFile(string path)
        {
            Helper.DumpObjectToBinaryFile(this, path);
        }
        internal static Configurations DeserializeFromBinaryFile(string path)
        {
            return Helper.GetObjectFromBinaryFile<Collection<Configuration>>(path);
        }
    }
