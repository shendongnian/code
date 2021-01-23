    public class DerivedClass : BaseClass
    {
        public DerivedClass():base() { }
    
        protected override MyBase WorkField 
        { 
            get 
            { 
                return new MyExtend(); 
            }
        }
    
        //public new int WorkProperty
        //{
        //    get { return 0; }
        //}
    }
