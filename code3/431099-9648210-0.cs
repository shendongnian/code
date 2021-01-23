    public class Customer
    {
        public int ID { get; set; }
        
        // this is necessary to have access to the related Bs/Cs
        // also it cant be private otherwise EF will not overload it properly
        public virtual ICollection<A> As { get; set; }
        public IEnumerable<B> Bs { get { return this.As.OfType<B>(); } }
        public IEnumerable<C> Cs { get { return this.As.OfType<C>(); } }
    }
