       namespace SendData
        {
          public class SendObjectData
            {
                static void Main(string[] args)
                {
              
                  Employee emp = new Employee();
                  emp.EmpName = "Raju";
                  emp.Age = 30;
                  emp.Profession = "Teacher";
        
                  POST(emp);
                }
        
               // This method post the object data to the specified URL.
                public static void POST(Employee objEmployee)
                {
                  //Serialize the object into stream before sending it to the remote server
                    MemoryStream memmoryStream = new MemoryStream();
                    BinaryFormatter binayformator = new BinaryFormatter();
                    binayformator.Serialize(memmoryStream, objEmployee);
        
                  //Cretae a web request where object would be sent
                    WebRequest objWebRequest = WebRequest.Create(@"http://localhost/XMLProvider/XMLProcessorHandler.ashx");
                    objWebRequest.Method = "POST";
                    objWebRequest.ContentLength = memmoryStream.Length;
                  // Create a request stream which holds request data
                    Stream reqStream = objWebRequest.GetRequestStream();
                 //Write the memory stream data into stream object before send it.
                    byte[] buffer = new byte[memmoryStream.Length];
                    int count = memmoryStream.Read(buffer, 0, buffer.Length);
                    reqStream.Write(buffer, 0, buffer.Length);
           
                 //Send a request and wait for response.
                    try
                    {
                        WebResponse objResponse = objWebRequest.GetResponse();
                 //Get a stream from the response.
                        Stream streamdata = objResponse.GetResponseStream();
                 //read the response using streamreader class as stream is read by reader class.
                        StreamReader strReader = new StreamReader(streamdata);
                        string responseData = strReader.ReadToEnd();
                    }
                    catch (WebException ex) {
                        throw ex;
                    }
                
                }
            }
        
            [Serializable]
            public class Employee
            {
        
                public string EmpName { get; set; }
                public int Age { get; set; }
                public string Profession { get; set; }
            
            }
        }
