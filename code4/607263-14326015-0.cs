    var mock = new Mock<IA>();
    //this will be a string, and contain just ""
    var yourMatcher = Match.Create<string> (s => s.Length == 3);
    mock.Object.Method ("muh");
    //this will fail because "muh" != ""
    mock.Verify (m => m.Method (yourMatcher));
    public interface IA
    {
      void Method (string arg);
    }
