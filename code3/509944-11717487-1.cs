    [ProtoContract]
    public class PartCollectionSurrogate
    {
        [ProtoMember(1)]
        private List<Part> Collection { get; set; }
        [ProtoMember(2, AsReference = true)]
        private Whole Whole { get; set; }
        public static implicit operator PartCollectionSurrogate(PartCollection value)
        {
            if (value == null) return null;
            return new PartCollectionSurrogate { Collection = value, Whole = value.Whole };
        }
        public static implicit operator PartCollection(PartCollectionSurrogate value)
        {
            if (value == null) return null;
            PartCollection result = new PartCollection {Whole = value.Whole};
            if(value.Collection != null)
            { // add the data we colated
                result.AddRange(value.Collection);
            }
            return result;
        }
    }
