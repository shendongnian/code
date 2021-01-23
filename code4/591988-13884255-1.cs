    [DataContract]
    public class SuggestionLister
    {
         [DataMember]
        public List<MovieResults> Search { get; set; }
    }
