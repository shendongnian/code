    [ProtoContract(IgnoreListHandling = true)]
    public class PartCollection : List<Part>
    {
        public Whole Whole { get; set; }
    }
