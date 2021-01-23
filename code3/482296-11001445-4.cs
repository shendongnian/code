    public class Manager
    {
        /// <summary>
        /// BindingList<T> fires ListChanged event when a new item is added to the list. 
        /// Since BindingSource hooks on to the ListChanged event of BindingList<T> it also is
        /// “aware” of these changes and so the BindingSource fires the ListChanged event. 
        /// This will cause the new row to appear instantly in the List, DataGridView or make any
        /// controls listening to the BindingSource “aware” about this change.
        /// </summary>
        public  BindingList<string> Messages { get; set; }
        private BindingSource _bs;
    
        private Form1 _form;
    
        public Manager(Form1 form)
        { 
            // note that Manager initialised with a set of 3 values
            Messages = new BindingList<string> {"2", "3", "4"};
            
            // initialise the bindingsource with the List - THIS IS THE KEY  
            _bs = new BindingSource {DataSource = Messages};
            _form = form;
        }
    
        public void UpdateList()
        {
             // pass the BindingSource and NOT the LIST
            _form.SetBinding(_bs);
        }
    }
