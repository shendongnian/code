using System.IO;
using System.Text.RegularExpressions;
using System.Web;
/// <summary>
/// The purpose of this class is to easily modify the form "action" of a given asp.net page.
/// To modify the action, call the following code in the code-behind of your page (or, better, your MasterPage):
/// Copied (and modified) from http://www.codeproject.com/KB/aspnet/ASP_Net_Form_Action_Attr.aspx
/// </summary>
public class FormActionModifier : Stream
{
  private const string FORM_REGEX = "(<form.*action=\")([^\"]*)(\"[^>]*>)";
  private Stream _sink;
  private long _position;
  string _url;
  public FormActionModifier(Stream sink, string url)
  {
    _sink = sink;
    _url = string.Format("$1{0}$3", url);
  }
  public override bool CanRead
  {
    get { return true; }
  }
  public override bool CanSeek
  {
    get { return true; }
  }
  public override bool CanWrite
  {
    get { return true; }
  }
  public override long Length
  {
    get { return 0; }
  }
  public override long Position
  {
    get { return _position; }
    set { _position = value; }
  }
  public override long Seek(long offset, System.IO.SeekOrigin direction)
  {
    return _sink.Seek(offset, direction);
  }
  public override void SetLength(long length)
  {
    _sink.SetLength(length);
  }
  public override void Close()
  {
    _sink.Close();
  }
  public override void Flush()
  {
    _sink.Flush();
  }
  public override int Read(byte[] buffer, int offset, int count)
  {
    return _sink.Read(buffer, offset, count);
  }
  public override void Write(byte[] buffer, int offset, int count)
  {
    string s = System.Text.UTF8Encoding.UTF8.GetString(buffer, offset, count);
    Regex reg = new Regex(FORM_REGEX, RegexOptions.IgnoreCase);
    Match m = reg.Match(s);
    if (m.Success)
    {
      string form = reg.Replace(m.Value, _url);
      int iform = m.Index;
      int lform = m.Length;
      s = string.Concat(s.Substring(0, iform), form, s.Substring(iform + lform));
    }
    byte[] yaz = System.Text.UTF8Encoding.UTF8.GetBytes(s);
    _sink.Write(yaz, 0, yaz.Length);
  }
  /// <summary>
  /// Sets the Form Action to the url specified
  /// </summary>
  public static void SetFormAction(string url)
  {
    if (HttpContext.Current != null)
      HttpContext.Current.Response.Filter = new FormActionModifier(HttpContext.Current.Response.Filter, url);
  } // SetFormAction()
} // class
