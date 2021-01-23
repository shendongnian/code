    public class SomeModel
    {
        [MustBeGreaterIf(OtherPropertyName="Prop2")]
        public string Prop1 {get;set;}
        public string Prop2 {get;set;}
    }
