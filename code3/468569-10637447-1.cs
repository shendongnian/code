    public class CustomClass
    {
        string name;
        List<int> intLost = new List<int>();
        public override bool Equals(object obj)
        {
            return this.Equals(obj as CustomClass);
        }
        public override int GetHashCode()
        {
            return 0;
        }
        public bool Equals(CustomClass cc)
        {
            if (cc == null) return false;
            return this.name.Equals(cc.name);
        }
    }
