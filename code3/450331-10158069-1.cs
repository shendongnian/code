    public class MyOwnStringBuilder
    {
       public StringBuilder Builder;
                
        
       public MyOwnStringBuilder()
       {
          this.Builder = new StringBuilder();
       }
        
       public static MyOwnStringBuilder Root
       {
         get{return new MyOwnStringBuilder();}
       }
        
       public string End
       {
         get{return Builder.ToString();}
       }
        
       public MyOwnStringBuilder And(string value)
       {
         Builder.Append(value);
         return this;
       }
        
       public MyOwnStringBuilder AnyInt(string value)
       {
          Builder.Append(value);
          return this;
       }
    }
