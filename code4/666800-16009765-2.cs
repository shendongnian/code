    public static Class Constants
         {
    		private static string _RootPath;
                    private static string _iOSRootPath;
    		private static string _AndroidResourcePath;
    
    		public static string RootPath
    		{
    			get
    			{
    				if (string.IsNullOrEmpty(_RootPath))
    				{
    					_RootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace(FileURIPrefix, "") + "\\My Documents\\Business";
    				}
    				return _RootPath;
    			}
    		}
    
    		public static string iOSRootPath
    		{
    			get
    			{
                              if (!string.IsNullOrEmpty(_iOSRootPath)) 
                              {
    			           _iOSRootPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace(FileURIPrefix, "").Replace("file:", ""), Path.Combine("My_Documents", "Business"));
    			      }
                              return _iOSRootPath;
                         }
    		}
    
    		public static string AndroidResourcePath
    		{
    			get
    			{
    				if (string.IsNullOrEmpty(_AndroidResourcePath))
    				{
    					_AndroidResourcePath = "Leopard.Delivery.My_Documents.Business.";
    				}
    				return _AndroidResourcePath;
    			}
    		}
      }
