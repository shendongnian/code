    public class Foo
    {
       public Func<string,bool> TheDelegate {get;set;}
    }
    public class Bar
    {
       public bool Implementation(string s)
       {
          return s == "True";
       }
    }
    public class Usage
    {
        var myBar = new Bar();
        var myFoo = new Foo { TheDelegate = myBar.Implementation };
    
        //Or
     
        var myFoo = new Foo { TheDelegate = x => x == "True" };   
        //This removes the need for Bar completely
    }
