     var webException = arg.Error as WebException;
     if(webException == null) return;
    
     
       if (webException.Response != null)
       { 
         var response = (HttpWebResponse)webException.Response; 
         var status  = response.StatusCode; //press F9 here
       }
                    
