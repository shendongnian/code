    public class DataGridField
    {
        public string this[string index]
        {
            get { return this.Key; }
            set
            {
                this.Key = index;
            }
         }
     }
