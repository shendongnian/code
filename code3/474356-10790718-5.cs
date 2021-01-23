    public struct  Person
    {
        public int ID;
        public static bool operator ==(Person a, Person b) { return Math.Abs(a.ID - b.ID) <= 5; }
        public static bool operator !=(Person a, Person b) { return Math.Abs(a.ID - b.ID) > 5; }
    }
