    public class SomeViewModel
    {
        public string Context 
        {
            get 
            { 
                if (IsEditMode && _r.Name == IsLoggedInAs) return "Current";
                else return "Other";
            }
        }  
 
        // ... snip other code
    }
