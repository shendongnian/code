    public class ClassA
    {
       public int Id
       public string name;
    
       private ClassB myObjectB;
       public ClassB MyObjectB { 
          get { return myObjectB ?? (myObjectB = list2.FirstOrDefault(x => this.Id == x.Id)); } 
       }
    }
