interface IRawenWriterFactory
{
  object Create();
}
class RawenWriterFactory&lt;T&gt; : IRawenWriterFactory
{
  public object Create()
  {
    Expression&lt;Func&lt;IDataEntity, DateTime&gt;&gt; func = x =&gt; x.CicReadTime;
    var ravenWriter = new RavenWriterBase&lt;T&gt;();
    ravenWriter.Initialize(60, func);
    return ravenWriter;
  }
}
