    public partial class Default : System.Web.UI.Page
        {
            ListSuggestions listSuggestions;
            public string[] companiesArray;
    
            //A constructor
            public  Default()
            {
             listSuggestions= new ListSuggestions();
             companiesArray = listSuggestions.loadArray(ref companiesArray);
            }
            //Serializer
            public class JavaScript
            {
                public static string Serialize(object o)
                {
                 JavaScriptSerializer js = new JavaScriptSerializer();
                 return js.Serialize(o);
                 }
              }
         }
