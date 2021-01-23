    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using RestSharp;
    using System.Web.Script.Serialization;
    using System.IO;
    using System.Net;
    
    namespace RonRestClient
    {
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                string path = @"C:\Projectos\My Training Samples\Adobe Sample\RBO1574.pdf";
                //localhost settings
                string requestHost = @"http://localhost:3000/receipts";
                string tagnr = "p94tt7w";
                string machinenr = "2803433";
                string safe_token = "123";
    
                FileStream fs1 = File.OpenRead(path);
                long filesize = fs1.Length;
                fs1.Close();
    
                // Create a http request to the server endpoint that will pick up the
                // file and file description.
                HttpWebRequest requestToServerEndpoint =
                    (HttpWebRequest)WebRequest.Create(requestHost);
    
                string boundaryString = "FFF3F395A90B452BB8BEDC878DDBD152";
                string fileUrl = path;
    
                // Set the http request header \\
                requestToServerEndpoint.Method = WebRequestMethods.Http.Post;
                requestToServerEndpoint.ContentType = "multipart/form-data; boundary=" + boundaryString;
                requestToServerEndpoint.KeepAlive = true;
                requestToServerEndpoint.Credentials = System.Net.CredentialCache.DefaultCredentials;
                requestToServerEndpoint.Accept = "application/json";
    
    
                // Use a MemoryStream to form the post data request,
                // so that we can get the content-length attribute.
                MemoryStream postDataStream = new MemoryStream();
                StreamWriter postDataWriter = new StreamWriter(postDataStream);
    
                // Include value from the tag_number text area in the post data
                postDataWriter.Write("\r\n--" + boundaryString + "\r\n");
                postDataWriter.Write("Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}",
                                        "receipt[tag_number]",
                                        tagnr);
    
                // Include ispaperduplicate text area in the post data
                postDataWriter.Write("\r\n--" + boundaryString + "\r\n");
                postDataWriter.Write("Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}",
                                        "receipt[ispaperduplicate]",
                                        0);
    
                // Include value from the machine number in the post data
                postDataWriter.Write("\r\n--" + boundaryString + "\r\n");
                postDataWriter.Write("Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}",
                                        "machine[serial_number]",
                                        machinenr);
    
                // Include value from the machine token in the post data
                postDataWriter.Write("\r\n--" + boundaryString + "\r\n");
                postDataWriter.Write("Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}",
                                        "machine[safe_token]",
                                        safe_token);
    
                // Include the file in the post data
                postDataWriter.Write("\r\n--" + boundaryString + "\r\n");
                postDataWriter.Write("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n"
                                        + "Content-Length: \"{2}\"\r\n"
                                        + "Content-Type: application/octet-stream\r\n"
                                        + "Content-Transfer-Encoding: binary\r\n\r\n",
                                        "receipt[receipt_file]",
                                        Path.GetFileName(fileUrl),
                                        filesize);
    
                postDataWriter.Flush();
    
    
                // Read the file
                FileStream fileStream = new FileStream(fileUrl, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    postDataStream.Write(buffer, 0, bytesRead);
                }
                fileStream.Close();
    
                postDataWriter.Write("\r\n--" + boundaryString + "--\r\n");
                postDataWriter.Flush();
    
                // Set the http request body content length
                requestToServerEndpoint.ContentLength = postDataStream.Length;
    
                // Dump the post data from the memory stream to the request stream
                Stream s = requestToServerEndpoint.GetRequestStream();
    
                postDataStream.WriteTo(s);
    
                postDataStream.Close();
       
            }
    
        }
    
    }
