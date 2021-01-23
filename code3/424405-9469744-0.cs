        using System;
    using System.IO;
    using System.Web;
     
    public class Download
    {
     
     
    public static void SmallFile(string filename, string filepath, string contentType)
    {
    try
    {
    FileStream MyFileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
    long FileSize;
    FileSize = MyFileStream.Length;
    byte[] Buffer = new byte[(int)FileSize];
    MyFileStream.Read(Buffer, 0, (int)MyFileStream.Length);
    MyFileStream.Close();
    HttpContext.Current.Response.ContentType = contentType;
    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8));
    HttpContext.Current.Response.BinaryWrite(Buffer);
     
    }
    catch
    {
    HttpContext.Current.Response.ContentType = "text/html";
    HttpContext.Current.Response.Write("Downloading Error!");
    }
    HttpContext.Current.Response.End();
    }
    public static void LargeFile(string filename, string filepath, string contentType)
    {
    Stream iStream = null;
    // Buffer to read 10K bytes in chunk
    //byte[] buffer = new Byte[10000];
    // Buffer to read 1024K bytes in chunk
     
     
    byte[] buffer = new Byte[1048576];
     
    // Length of the file:
     
     
    int length;
    // Total bytes to read:
     
     
    long dataToRead;
     
    try
    {
    // Open the file.
     
     
    iStream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
    // Total bytes to read:
     
     
    dataToRead = iStream.Length;
    HttpContext.Current.Response.ContentType = contentType;
    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8));
    // Read the bytes.
     
     
    while (dataToRead > 0)
    {
    // Verify that the client is connected.
     
     
    if (HttpContext.Current.Response.IsClientConnected)
    {
    // Read the data in buffer.
     
     
    length = iStream.Read(buffer, 0, 10000);
     
    // Write the data to the current output stream.
     
     
    HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);
     
    // Flush the data to the HTML output.
     
     
    HttpContext.Current.Response.Flush();
     
    buffer = new Byte[10000];
    dataToRead = dataToRead - length;
    }
    else
    {
    //prevent infinite loop if user disconnects
     
     
    dataToRead = -1;
    }
    }
    }
    catch (Exception ex)
    {
    // Trap the error, if any.
    //HttpContext.Current.Response.Write("Error : " + ex.Message);
     
     
    HttpContext.Current.Response.ContentType = "text/html";
    HttpContext.Current.Response.Write("Error : file not found");
     
    }
    finally
    {
    if (iStream != null)
    {
    //Close the file.
     
     
    iStream.Close();
    }
    HttpContext.Current.Response.End();
    HttpContext.Current.Response.Close();
     
    }
     
    }
    public static void ResumableFile(string filename, string fullpath, string contentType)
    {
    try
    {
    FileStream myFile = new FileStream(fullpath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
    BinaryReader br = new BinaryReader(myFile);
    try
    {
    HttpContext.Current.Response.AddHeader("Accept-Ranges", "bytes");
    HttpContext.Current.Response.Buffer = false;
    long fileLength = myFile.Length;
    long startBytes = 0;
     
    //int pack = 10240; //10K bytes
     
     
    int pack = 1048576; //1024K bytes
     
     
    if (HttpContext.Current.Request.Headers["Range"] != null)
    {
    HttpContext.Current.Response.StatusCode = 206;
    string[] range = HttpContext.Current.Request.Headers["Range"].Split(new char[] { '=', '-' });
    startBytes = Convert.ToInt64(range[1]);
    }
    HttpContext.Current.Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
    if (startBytes != 0)
    {
    HttpContext.Current.Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
    }
    HttpContext.Current.Response.AddHeader("Connection", "Keep-Alive");
    HttpContext.Current.Response.ContentType = contentType;
    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8));
     
    br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
    int maxCount = (int)Math.Floor((double)((fileLength - startBytes) / pack)) + 1;
     
    for (int i = 0; i < maxCount; i++)
    {
    if (HttpContext.Current.Response.IsClientConnected)
    {
    HttpContext.Current.Response.BinaryWrite(br.ReadBytes(pack));
    }
    else
    {
    i = maxCount;
    }
    }
    }
    catch
    {
    HttpContext.Current.Response.ContentType = "text/html";
    HttpContext.Current.Response.Write("Error : file not found");
    }
    finally
    {
    br.Close();
    myFile.Close();
    }
    }
    catch
    {
    HttpContext.Current.Response.ContentType = "text/html";
    HttpContext.Current.Response.Write("Error : file not found");
    }
    }
     
    }
