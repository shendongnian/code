    public class AClass
    {
        private int privateMemberA;
    
        // This version of Equals has been simplified
        // for the purpose of exemplifying my point, it shouldn't be copied as is
        public override bool Equals(object obj)
        {
            var otherInstance = obj as AClass;
            if (otherInstance == null)
            {
                return null;
            }
            return otherInstance.privateMemberA == this.privateMemberA;
        }
    }
