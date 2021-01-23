    public partial class Test
    {
        partial void OnCtor() // implement the partial method
        {
           //some code
        }
    }
    public partial class Test
    {
        partial void OnCtor(); // declare the partial method
        Test()
        {
            days = new List<SelectListItem>();
            OnCtor();          // invoke the partial method **if implemented**
        }
    
        public IList<SelectListItem> days { get; set; }
    }
