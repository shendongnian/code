    public class A
    {
        public int Id { get; set; }
        public B BValue { get; set; }
        public A()
        {
            this.Id = 1000;
            this.BValue = new B();
        }
    }
    public class B
    {
        public string Name { get; set; }
        public C CValue { get; set; }
        [NoLog]
        public string Secret { get; set; }
        public B()
        {
            this.Name = "Empty Name";
            this.CValue = new C();
        }
    }
    public class C
    {
        public string Description { get; set; }
        public C()
        {
            this.Description = "Empty Description";           
        }
    }
