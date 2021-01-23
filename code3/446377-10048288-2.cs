    public class ClassBeingTested
    {
        public AwesomeDal DAL { get; set; }
        public ClassBeingTested() : this(new AwesomeDal()){}
        public ClassBeingTested(AwesomeDal dal)
        {
           this.DAL = dal;
        }
    
        public void SomeMethod()
        {
            var name = "Hello";
            var motto = "World";                       
            this.DAL.AddCompany(name, motto);
        }
    }
