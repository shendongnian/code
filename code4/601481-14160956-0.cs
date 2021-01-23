    try {
      FileInfo file = new FileInfo(openedPdfs.path);    
      System.IO.File.Delete(openedPdfs.path);
      // if no exception is thrown then you should assume all has gone well and put  
      // your file successfully deleted code here.
    } catch /*(Specfic exceptions can be referenced here in separate catch blocks see Daniel A. White answer)*/ {
      // If something bad happened and the file was not deleted put handling code here
    } finally {
      // if some action needs to be taken regardless of whether the file was successfully deleted or not put 
      // that code here
    }
