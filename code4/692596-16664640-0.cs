    class RequiredInput
    {
        public property string Phrase { get; set;}
        public property Field[] Fields { get; set;}
    }
    class Field
    {
        public Type Type { get; set;}
        public object Default { get; set;}
        public object[] options { get; set;}
    }
