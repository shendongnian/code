    public class A
    {
        public int Id { get; set; }
        protected int protectedId { get; set; }
        private int privateId;
    }
    public class B : A
    {
    }
    public class C : B
    {
        public C()
        {
            int temp = Id; // works
            int temp1 = protectedId; // works
            int temp2 = privateId; // does NOT work
        }
    }
