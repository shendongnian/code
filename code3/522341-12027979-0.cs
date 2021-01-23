    public class Class1 : ICloneable {
        public string Prop1 { get; set; }
        public object Clone() {
            return new Class1 { Prop1 = Prop1 };
        }
    }
    public class Class2 : Class1 {
        public string Prop2 { get; set; }
        public new object Clone() {
            return new Class2 { Prop1 = Prop1, Prop2 = Prop2 };
        }
    }
