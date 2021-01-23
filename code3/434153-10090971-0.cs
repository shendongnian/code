    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace SampleService
    {
        public class MultipartParser
        {
            private byte[] requestData;
            public MultipartParser(Stream stream)
            {
                this.Parse(stream, Encoding.UTF8);
                ParseParameter(stream, Encoding.UTF8);
            }
    
            public MultipartParser(Stream stream, Encoding encoding)
            {
                this.Parse(stream, encoding);
            }
    
            private void Parse(Stream stream, Encoding encoding)
            {
                this.Success = false;
    
                // Read the stream into a byte array
                byte[] data = ToByteArray(stream);
                requestData = data;
    
                // Copy to a string for header parsing
                string content = encoding.GetString(data);
    
                // The first line should contain the delimiter
                int delimiterEndIndex = content.IndexOf("\r\n");
    
                if (delimiterEndIndex > -1)
                {
                    string delimiter = content.Substring(0, content.IndexOf("\r\n"));
    
                    // Look for Content-Type
                    Regex re = new Regex(@"(?<=Content\-Type:)(.*?)(?=\r\n\r\n)");
                    Match contentTypeMatch = re.Match(content);
    
                    // Look for filename
                    re = new Regex(@"(?<=filename\=\"")(.*?)(?=\"")");
                    Match filenameMatch = re.Match(content);
    
                    // Did we find the required values?
                    if (contentTypeMatch.Success && filenameMatch.Success)
                    {
                        // Set properties
                        this.ContentType = contentTypeMatch.Value.Trim();
                        this.Filename = filenameMatch.Value.Trim();
    
                        // Get the start & end indexes of the file contents
                        int startIndex = contentTypeMatch.Index + contentTypeMatch.Length + "\r\n\r\n".Length;
    
                        byte[] delimiterBytes = encoding.GetBytes("\r\n" + delimiter);
                        int endIndex = IndexOf(data, delimiterBytes, startIndex);
    
                        int contentLength = endIndex - startIndex;
    
                        // Extract the file contents from the byte array
                        byte[] fileData = new byte[contentLength];
    
                        Buffer.BlockCopy(data, startIndex, fileData, 0, contentLength);
    
                        this.FileContents = fileData;
                        this.Success = true;
                    }
                }
            }
    
            private void ParseParameter(Stream stream, Encoding encoding)
            {
                this.Success = false;
    
                // Read the stream into a byte array
                byte[] data;
                if (requestData.Length == 0)
                {
                    data = ToByteArray(stream);
                }
                else { data = requestData; }
                // Copy to a string for header parsing
                string content = encoding.GetString(data);
    
                // The first line should contain the delimiter
                int delimiterEndIndex = content.IndexOf("\r\n");
    
                if (delimiterEndIndex > -1)
                {
                    string delimiter = content.Substring(0, content.IndexOf("\r\n"));
                    string[] splitContents = content.Split(new[] {delimiter}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string t in splitContents)
                    {
                        // Look for Content-Type
                        Regex contentTypeRegex = new Regex(@"(?<=Content\-Type:)(.*?)(?=\r\n\r\n)");
                        Match contentTypeMatch = contentTypeRegex.Match(t);
    
                        // Look for name of parameter
                        Regex re = new Regex(@"(?<=name\=\"")(.*)");
                        Match name = re.Match(t);
    
                        // Look for filename
                        re = new Regex(@"(?<=filename\=\"")(.*?)(?=\"")");
                        Match filenameMatch = re.Match(t);
    
                        // Did we find the required values?
                        if (name.Success || filenameMatch.Success)
                        {
                            // Set properties
                            //this.ContentType = name.Value.Trim();
                            int startIndex;
                            if (filenameMatch.Success)
                            {
                                this.Filename = filenameMatch.Value.Trim();
                            }
                            if(contentTypeMatch.Success)
                            {
                                // Get the start & end indexes of the file contents
                                startIndex = contentTypeMatch.Index + contentTypeMatch.Length + "\r\n\r\n".Length;
                            }
                            else
                            {
                                startIndex = name.Index + name.Length + "\r\n\r\n".Length;
                            }
    
                            //byte[] delimiterBytes = encoding.GetBytes("\r\n" + delimiter);
                            //int endIndex = IndexOf(data, delimiterBytes, startIndex);
    
                            //int contentLength = t.Length - startIndex;
                            string propertyData = t.Substring(startIndex - 1, t.Length - startIndex);
                            // Extract the file contents from the byte array
                            //byte[] paramData = new byte[contentLength];
    
                            //Buffer.BlockCopy(data, startIndex, paramData, 0, contentLength);
    
                            MyContent myContent = new MyContent();
                            myContent.Data = encoding.GetBytes(propertyData);
                            myContent.StringData = propertyData;
                            myContent.PropertyName = name.Value.Trim();
    
                            if (MyContents == null)
                                MyContents = new List<MyContent>();
    
                            MyContents.Add(myContent);
                            this.Success = true;
                        }
                    }
                }
            }
    
            private int IndexOf(byte[] searchWithin, byte[] serachFor, int startIndex)
            {
                int index = 0;
                int startPos = Array.IndexOf(searchWithin, serachFor[0], startIndex);
    
                if (startPos != -1)
                {
                    while ((startPos + index) < searchWithin.Length)
                    {
                        if (searchWithin[startPos + index] == serachFor[index])
                        {
                            index++;
                            if (index == serachFor.Length)
                            {
                                return startPos;
                            }
                        }
                        else
                        {
                            startPos = Array.IndexOf<byte>(searchWithin, serachFor[0], startPos + index);
                            if (startPos == -1)
                            {
                                return -1;
                            }
                            index = 0;
                        }
                    }
                }
    
                return -1;
            }
    
            private byte[] ToByteArray(Stream stream)
            {
                byte[] buffer = new byte[32768];
                using (MemoryStream ms = new MemoryStream())
                {
                    while (true)
                    {
                        int read = stream.Read(buffer, 0, buffer.Length);
                        if (read <= 0)
                            return ms.ToArray();
                        ms.Write(buffer, 0, read);
                    }
                }
            }
    
            public List<MyContent> MyContents { get; set; }
            
            public bool Success
            {
                get;
                private set;
            }
    
            public string ContentType
            {
                get;
                private set;
            }
    
            public string Filename
            {
                get;
                private set;
            }
    
            public byte[] FileContents
            {
                get;
                private set;
            }
        }
    
        public class MyContent
        {
            public byte[] Data { get; set; }
            public string PropertyName { get; set; }
            public string StringData { get; set; }
        }
    }
