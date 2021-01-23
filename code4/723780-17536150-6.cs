    public class MyClass
    {
    
       private void Set(int i,string value)
       {
           Console.WriteLine("Your Index:{0}\r\nSet Value:{1}",i,value);
       }
       
       public string this[int i]
       {
            get
            {
                if(i<0)
                   return "less than zero"; 
                if(i==0)
                   return "This is zero";
                else if(i==1)
                   return "This is one";
                else if(i==2)
                   return "this is two";
                else
                   return "more than two";
                
            }
            set
            {
               //value is a key word in a setter
               //representing the value on you are attempting to set
               Set(i,value);
            }
        }
    }
