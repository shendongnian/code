    public class Parent
    {
        private object _member;
        public Parent(object member)
        {
            this._member = member;
        }
    }
    public class Child : Parent
    {
        public Child(object member)
            : base(member)
        {
        }
    }
