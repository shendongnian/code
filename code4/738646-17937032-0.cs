    public class Test
    {
       public object doSomething(string txt)
       {
          ...
          return new 
          {
              text = "some return value",
              success = true
          };
       }
    }
    var result = testInstance.doSomething("instr");
    //    result.text
    //    result.success
