    class SomeClass
    {
        string value;
        public SomeClass(string _Value)
        {
            value = _Value;
        }
        static public bool operator ==(SomeClass C1, SomeClass C2)
        {
            return C1.value == C2.value;
        }
        public override bool Equals(SomeClass C1)
        {
            // causes error due to unsure which operator == to use the SomeClass == or the object ==
            // Actual error: Operator '==' is ambiguous on operands of type 'SomeClass' and '<null>'
            if (C1 == null)
                return false;
            // Give same error as above
            if (C1 == default(SomeClass))
                return false;
            // Removes ambiguity and compares using base objects == to null
            if ((object)C1 == null)
                return false;
            return value == C1.value;
        }
    }
