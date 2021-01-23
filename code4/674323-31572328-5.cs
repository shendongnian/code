    public  interface   IPerson
    {
        string  FirstName;
        string  LastName;
    }
    public  interface   ILock
    {
        object  GetLock();
    }
    public  interface   ILockablePerson : IComposite<ILockablePerson, IPerson, ILockable>, IPerson, ILockable {}
    public  class       Person : IPerson
    {
        public  string  FirstName   { get; set; }
        public  string  LastName    { get; set; }
    }
    public  class       Lock : ILock
    {
        private
        readonly    object  lock        = new object();
        public      object  GetLock()   { return this.lock; }
    }
    
    public  class       UseLockablePerson
    {
        public  void    Main()
        {
            var     lockablePerson  = ILockablePerson.Composer.Create(new Person(), new Lock());
            lock(lockablePerson.GetLock())
            {
                lockablePerson.FirstName    = "Bob";
            }
        }
    }
