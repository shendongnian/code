    public class JsonFormatter : JsonMediaTypeFormatter{
    public override System.Threading.Tasks.Task<object> ReadFromStreamAsync(Type type, System.IO.Stream stream, System.Net.Http.Headers.HttpContentHeaders contentHeaders, IFormatterLogger formatterLogger)
    {
       System.Threading.Tasks.Task<object> task = base.ReadFromStreamAsync(type, stream, contentHeaders, formatterLogger);
        //parse error if null
       if (task.Result == null)
       {
           //handle error here.
       }
       return task;
    }}
public class XMLFormatter : XmlMediaTypeFormatter
{
    public override System.Threading.Tasks.Task<object> ReadFromStreamAsync(Type type, System.IO.Stream stream, System.Net.Http.Headers.HttpContentHeaders contentHeaders, IFormatterLogger formatterLogger)
    {
        System.Threading.Tasks.Task<object> task = base.ReadFromStreamAsync(type, stream, contentHeaders, formatterLogger);
        //parse error if null
        if (task.Result == null)
        {
            //handle error here
        }
        return task;
    }
}
