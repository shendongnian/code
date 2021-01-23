    public class BaseDAL
    {
        // Singleton Instance
        protected Sql _dal = Sql.Instance;
    
        public string CommandName = string.Empty;
        public List<Object> Parameters = new List<Object>();
    
        public void Save()   
        {
            List<Object> Params = this.SaveEntity();
            _dal.ExecuteNonQuery(CommandName, Params.ToArray());
        }
    
        public void Delete() 
        {
            List<Object> Params = this.DeleteEntity();
            _dal.ExecuteNonQuery(CommandName, Params.ToArray());
        }
    
        public void Update() 
        {
            List<Object> Params = this.UpdateEntity();
            _dal.ExecuteNonQuery(CommandName, Params.ToArray());
        }
    
        protected virtual List<Object> SaveEntity()
        {
            return null;
        }
        protected virtual List<Object> UpdateEntity()
        { 
            return null;
        }
        protected virtual List<Object> DeleteEntity()
        {
            return null;
        }
    
       // Other functions, like DataTable and DataSet querying
    }
