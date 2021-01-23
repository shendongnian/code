    public class Signature : ITestJson, ITestRest, ITestBoth
    {
      public string Echo(string Text)
      {
        return Text;
      }
      public string EchoR(string Text)
      {
        return Text;
      }
      public string EchoJ(string Text)
      {
        return Text;
      }
