    public class MyStaticClass
    {
       public StringBuilder Builder;
                
        
       public MyStaticClass()
       {
          this.Builder = new StringBuilder();
       }
        
       public static MyStaticClass Root
       {
         get{return new MyStaticClass();}
       }
        
       public string End
       {
         get{return Builder.ToString();}
       }
        
       public MyStaticClass And(string value)
       {
         Builder.Append(elemName);
         return this;
       }
        
       public MyStaticClass AnyInt(string value)
       {
          Builder.Append(elemName);
          return this;
       }
    }
