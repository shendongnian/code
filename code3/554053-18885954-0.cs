    using System;
    using System.Linq;
    using System.Text;
    using System.IO.Packaging;
    using System.IO;
    namespace TestZip
    {
     public static class  Program
     {
      public static void Main(string[] args)
      {
       byte[] data = Encoding.UTF8.GetBytes(String.Join("\n", new string[1000].Select(s => "Something to zip.").ToArray()));
       byte[] zippedBytes;
       using(MemoryStream zipStream = new MemoryStream())
       {
        using (Package package = Package.Open(zipStream, FileMode.Create))
        {
         PackagePart document = package.CreatePart(new Uri("/test.txt", UriKind.Relative), "");
         using (MemoryStream dataStream = new MemoryStream(data))
         {
          document.GetStream().WriteAll(dataStream);
         }     
        }    
        zippedBytes = zipStream.ToArray();
       }
       File.WriteAllBytes("test.zip", zippedBytes);
      }
      private static void WriteAll(this Stream target, Stream source)
      {
       const int bufSize = 0x1000;
       byte[] buf = new byte[bufSize];
       int bytesRead = 0;
       while ((bytesRead = source.Read(buf, 0, bufSize)) > 0)
        target.Write(buf, 0, bytesRead);
      }
     }
    }
