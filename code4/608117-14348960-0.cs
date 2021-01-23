     static bool IsProtected(String filePath)
     {
           try
           {
                FileAttributes attributes = System.IO.File.GetAttributes(filePath);
                if(attributes == FileAttributes.Encrypted)
                    return true;
                else 
                    return false;
           }
           catch(UnauthorizedAccessException ex)
           {
               // your code here
               // I would return false, given that you need to upload it which would require permission I think.
           }
           catch(// other exceptions you want)
           {
              // your code
           }
