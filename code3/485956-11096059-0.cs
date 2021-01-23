     public class MyDataContextClass
     {
         private string showThis = string.Enpty;
         public string ShowThis
         {
             get {return showThis;}
             set
             {
                  showThis = value;
                  if (PropertyChanged != null)
                      PropertyChanged(....);
             }
          }
      }
