    public class MyViewModel
    {
        private string _id;
        public string Id
        {
            get { return _id; }
            set 
            { 
                _id = value; 
                UpdateConvertedName(_id);
            }
        }
    
        private void UpdateConvertedName(string id)
        {
            // Same as your 'Convert' code above
        }
    
        private void inv_Completed(object sender, EventArgs e)
        {
            Name = inv.Value;        
        } 
    
        public string Name { get; set; }
    }
