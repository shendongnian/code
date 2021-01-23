public interface ParameterSource
{
    public string Path {get; }
}
public class FakeParameterSource : ParameterSource
{
   public string Value;
   public string Path { get { return Value } }
}
public class RealParameterSource : ParameterSource
{
   private HttpRequest request;
   public RealParameterSource(HttpRequest aRequest)
   {
     request = aRequest;
   }
   public string Path { get { return request.Path } }
}
