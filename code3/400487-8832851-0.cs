    class MyException : Exception
    {
       public readonly int status;
       public  MyException(int status, string msg):base(msg)
       {
          this.status = status;
       }
    }
    
    public string Method1()
    {   
       throw new MyException(-1,"msg");
        return "0";
    }
   
    SomeCode()
        {
        
             try
             {
                      Method1();
             }catch(MyException ex)
             { 
                ex.status //here you get the status
              }
         }
