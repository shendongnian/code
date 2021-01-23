    public class MySuperGridView : GridView
    {
    
        public void CoolMethod()
        {
        }
    
        public string CoolProperty 
       {
           get{return ViewState["CoolProperty"]==null?null:(string)ViewState["CoolProperty"];}
           set {ViewState ["CoolProperty"]=value;}
       }
        //add more coolness here
    }
