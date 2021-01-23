    public class MyFirstView : Form
    {    
      private ModelClass m_model;
      public MyFirstView(ModelClass model)
      {
         m_model = model;
         m_model.OnDataRefresh += this.Model_OnDataRefresh;
      }   
    }
    
    public class MySecondView : Form
    {    
      private ModelClass m_model;
      public MySecondView(ModelClass model)
      {
         m_model = model;
         m_model.OnDataRefresh += this.Model_OnDataRefresh; 
      }   
    }
    public class ModelClass 
    {
       private DataAccessClass m_dataAccess;
       public event EventHandler OnDataRefresh = {}; // fired when data is refreshed
    
       public void EnsureDataIsLoaded();  // queries the db if we haven't already
       public void RefreshData(); // refreshes the data from the db
       public IList<Entity> GetDataList(); // access to data items
    }
