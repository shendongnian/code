    [DataContract(Name="a")]
    public class A1
    {
        [DataMember(Name = "b")]
        public int? B { get; set; }
        [DataMember(Name = "c")]
        private string _c { get; set; }
        public int? C
        {
            get
            {
                int retval;
                return !string.IsNullOrWhiteSpace(_c) && int.TryParse(_c, out retval) ? (int?)retval : null;
            }
        }
    }
