    public class ProductNodesProvider : IDynamicNodeProvider
    {
      static readonly string AllProductsQuery = 
        "SELECT Id, Title, Category FROM dbo.Product;";
      string connectionString = 
    		ConfigurationManager.ConnectionStrings ["db"].ConnectionString;
    	
      /// Create DynamicNode's out of all Products in our database
      public System.Collections.Generic.IEnumerable<DynamicNode> GetDynamicNodeCollection()
      {
        var returnValue = new List<DynamicNode> ();
    
        using (SqlConnection connection = new SqlConnection(connectionString)) {
          SqlCommand command = new SqlCommand (AllProductsQuery, connection);
          connection.Open ();
          SqlDataReader reader = command.ExecuteReader ();
          try {
            while (reader.Read()) {
              DynamicNode node = new DynamicNode (); 
              node.Title = reader [1]; 
              node.ParentKey = "Category_" + reader [2]; 
              node.RouteValues.Add ("productid", reader [0]);
    					
              returnValue.Add (node); 
            }
          } finally {
            reader.Close ();
          }
        }
    
        return returnValue;
      }
    
      /// Create CacheDependancy on SQL
      public CacheDescription GetCacheDescription ()
      {
        using (SqlConnection connection = new SqlConnection(connectionString)) {
          SqlCommand command = new SqlCommand (AllProductsQuery, connection);
          SqlCacheDependency dependancy = new SqlCacheDependency (command);
    			
          return new CacheDescription ("ProductNodesProvider")
          {
            Dependencies = dependancy
          };
        }
      }
    }
