    public class Foo
    {
        public int ID { get; set; }
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Foo f2 = obj as Foo;
            if (f2 == null) return false;
            return ID == f2.ID;
        }
    }
