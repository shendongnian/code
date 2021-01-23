    public class Person
    {
        public string Matriculation { get; set; }
        public string ID { get; set; }
        public string IDDependent { get; set; }
        public string Birthday { get; set; }
        public override string ToString()
        {
            return String.Format("{0} {1} ({2})", ID, Matriculation, Birthday);
        }
    }
