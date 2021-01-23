            public static class MyDictionary
       {
           public static Dictionary<string,string> French = new Dictionary<string,string>();
            
            public static Dictionary<string,string> English=new Dictionary<string,string>();
                public static MyDictionary(){   
              while ( dataReader.Read() ) {
               MyDictionary.English.Add( dataReader["field1"].ToString(),Localization.English(dataReader["field1"]));
               MyDictionary.French.Add( dataReader["field2"].ToString(),Localization.French(dataReader["field2"]));
              } 
            }        
          }
