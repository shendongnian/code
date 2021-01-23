    public class FacadedEmployeeModel : INavigationItem
    {
        private ContosoEmployeeModel model;
        public FacadedEmployeeModel(ContosoEmployeeModel model)
        {
            this.model = model;
        }
    
        // INavigationItem properties
        string INavigationItem.Name { get; set;}
    
        int INavigationItem.DBID { get; set;}
    
        ContosoEmployeeModel GetOriginalModel()
        { 
           return this.model;
        }   
    }
