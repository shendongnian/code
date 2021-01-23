public class Tests
  {
  public Tests(ITestOutputHelper output)
    {
    var type = output.GetType();
    var testMember = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic);
    var test = (ITest)testMember.GetValue(output);
    }
<...>
  }
  [1]: https://github.com/xunit/xunit/issues/416#issuecomment-378512739
