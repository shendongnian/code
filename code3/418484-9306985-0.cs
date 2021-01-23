    using Service;
    
    namespace MyService
    {
        class MyService : IServiceContract
        {
            public void Insert(string Name)
            {
                if (core == true)
                {
    		        var uploader = new Upload();
                    uploader.Uploading(XmlFile);
                }
                else
                {
    
                }
            }
    	}
    }
    
    
    namespace Service
    {
        class Upload
        {
            public void Uploading(string file)
            {
    		     console.writeline(file)
            }
        }
    }
