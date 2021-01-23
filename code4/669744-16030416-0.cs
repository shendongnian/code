    public class Sensitive{
     public String Name{  
       set{
        this.Name= YourEncryptionFunc(value)
       }
      get{
       return DecryptFunc(this.Name);
      }
      }
    }
