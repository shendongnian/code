    using System;
    using System.Web.Services;
    
    public partial class _Default : System.Web.UI.Page
    {
    
        [WebMethod]
        public static string retrieveData()
        {
            //Retrieve data from the server and return.
            return "This was returned from my database server." + DateTime.Now.ToString() ;
        }
    
        [WebMethod]
        public static bool insertData()
        {
            //Do all of the insert in the server blah blah blah
            //and return true or false if it was inserted.
            return true;
            
        }
    }
