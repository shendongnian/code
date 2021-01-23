    using System.Net;
    using System.IO;
    public class Ftp
    {
      private static void ftpUpload(string filename, string destinationURI)
      {
			FileInfo fileInfo = new FileInfo(filename);
			FtpWebRequest reqFTP = CreateFtpRequest(new Uri(destinationURI));
			reqFTP.KeepAlive = false;
			// Specify the command to be executed.
			reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
			// use binary 
			reqFTP.UseBinary = true;
			reqFTP.ContentLength = fileInfo.Length;
			// Buffer size set to 2kb
			const int buffLength = 2048;
			byte[] buff = new byte[buffLength];
			// Stream to which the file to be upload is written
			Stream strm = reqFTP.GetRequestStream();
			FileStream fs = fileInfo.OpenRead();
			// Read from the file stream 2kb at a time
			int cLen = fs.Read(buff, 0, buffLength);
			// Do a while till the stream ends
			while (cLen != 0)
			{
				// FTP Upload Stream
				strm.Write(buff, 0, cLen);
				cLen = fs.Read(buff, 0, buffLength);
			}
			// Close 
			strm.Close();
			fs.Close();
       }
     }
