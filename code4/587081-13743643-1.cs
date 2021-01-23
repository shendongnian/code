    public class Child : Parent 
    {
        public void LoadData() 
        {
            base.MyMethod(); // call method of parent class
            base.CurrentRow = 1; // set property of parent class
            // other stuff...
        }
    }
