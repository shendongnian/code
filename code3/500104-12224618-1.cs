    // c2012 Shawn Eary cc-wiki - Load DropDowns via AJAX Demo 
    // 
    // Shows how to use a WebMethod to selectively push possible 
    // DropDownList population data back to the client 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    /// <summary>
    /// Container for the data items that will be pushed back to the 
    /// client via JSON
    /// </summary>
    public class selectOption
    {
       public selectOption(int iValue, string iText)
       {
          value = iValue; 
          text = iText; 
       }
       public int value; 
       public string text; 
    }
    /// <summary>
    /// Summary description for testServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class testServices : System.Web.Services.WebService {
   
       // Send Data back to the client based upon the table of 
       // information she/he wants.  In real life, each of the different
       // if branches could be replaced with calls to the SQL database
       // to get the data but putting these calls here doesn't 
       // significantly enhance the purpose of this example
       [WebMethod]
       public List<selectOption> GetDropDownData(string tableName) {                  
          List<selectOption> returnVal = new List<selectOption>();
          if (tableName == "color") { 
             // Normally you would use Entity Framework to get information
             // from your T-SQL database here, but it isn't necessary
             // for me to show the database calls for this illustration
             returnVal.Add(new selectOption(1, "blue"));
             returnVal.Add(new selectOption(2, "yellow"));
             returnVal.Add(new selectOption(3, "green"));
          }
          else if (tableName == "shape")
          {
             // Normally you would use Entity Framework to get information
             // from your T-SQL database here, but it isn't necessary
             // for me to show the database calls for this illustration
             returnVal.Add(new selectOption(1, "square"));
             returnVal.Add(new selectOption(2, "triangle"));
             returnVal.Add(new selectOption(3, "oval"));
             returnVal.Add(new selectOption(4, "circle"));
          }
          else if (tableName == "size")
          {
             // Normally you would use Entity Framework to get information
             // from your T-SQL database here, but it isn't necessary
             // for me to show the database calls for this illustration
             returnVal.Add(new selectOption(1, "big"));
             returnVal.Add(new selectOption(2, "small"));         
          }
          return returnVal;
       }    
    }
