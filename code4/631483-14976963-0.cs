     try
                {
                    string username = "eval1";
                    string password = "dsfdf@";
                    
                    // Prepare web request...  
                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://someurl/login.php?username="+username+"&password="+password);
                    myRequest.Method = "GET";
                    myRequest.ContentType = "application/text";
                    
                    System.Net.HttpWebResponse hwresponse = (System.Net.HttpWebResponse)myRequest.GetResponse();
                    if (hwresponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        System.IO.Stream responseStream = hwresponse.GetResponseStream();
                        System.IO.StreamReader myStreamReader = new System.IO.StreamReader(responseStream);
                        responseData = myStreamReader.ReadToEnd().ToString().Trim();                   
                    }
                    hwresponse.Close();
        }
        catch(Exception e1)
        {
            Response.writeln("error message:"+e1)
        }
