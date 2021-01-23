    public sealed class MyStringField : ParentField<string>
    {
        public override Object Value
        {
            get { return valor; }
            set { valor = (string)value; }
        }
        public override string GetRealStrongTypedValue
        {
            get { return valor; } // ERROR...
        }
        private string valor;
    }
