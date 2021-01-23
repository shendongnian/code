    public class SomeClass
    {
        public SomeClass()
        {
            //set the default
            OverridableMethod = () => MessageBox.Show("Default!");
        }
    
        public void StandardMethod()
        {
            //Call it.
            OverridableMethod();
        }
    
        public Action OverridableMethod {get;set;}
    }
