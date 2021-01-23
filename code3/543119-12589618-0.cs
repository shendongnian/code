    "{ q: {file:\"dave\", type:\"ward\"} }"
---
    public class myClass
    {
         private string _file = string.empty;
         public string file {
             get { return _file; }
             set { _file = value.trim(); }
           }
      
         private string _type = string.empty;
         public string type {
             get { return _type; }
             set { _type = value.trim(); }
           }
    }
