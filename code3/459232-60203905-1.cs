string path = TextFile + ".txt";
if (!File.Exists(HttpContext.Current.Server.MapPath(path)))
{
    File.Create(HttpContext.Current.Server.MapPath(path)).Close();
}
using (StreamWriter w = File.AppendText(HttpContext.Current.Server.MapPath(path)))
{
    w.WriteLine("{0}", "Hello World");
    w.Flush();
    w.Close();
}
