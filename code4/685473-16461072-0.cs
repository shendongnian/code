    public class StringReference
    {
       public string Value {get; set;}
       public StringReference(string value)
       {
          Value = value;
       }
    }
    public class Test
    {
        internal StringReference mystr;
    }
    StringReference my = new StringReference("ABC");
    Test test = new Test();
    test.mystr = my;
    test.mystr.Value = "";
    // my.Value is now "" as well
    
