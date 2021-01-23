    public class OneDollar112ViewModel
    {
        private static MyEDM db = new MyEDM();
        private MyDBModel myModel;
        public string fldNo1 
        {
            get 
            { 
                return myModel == null
                    ? myModel.fldNo1
                    : null;
            }
            set 
            {
                // Your set logic here 
            }
        }    
        public OneDollar112ViewModel(Int32 number)
        {
            myModel = db.MyTable
                .Where(t => t.Current == 1 && t.No == numbner).SingleOrDefault();
        }
    }    
