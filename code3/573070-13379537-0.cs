    // I'm assuming a List of strings, fix accordingly
    public class A
    {
        //Not autoimplemented to ensure it's always initialized
        private List<string> items = new List<string>();
        public List<string> Items
        {
            get { return items; }
            set { items = value; }
        }
    }
    
    public class AnyoneElse
    {
         void someMethod()
         {
             A someVar = new A();
             A.Items.Add("This was added from outside");
             
             MessageBox.Show(A.Items.First());
         }
    }
