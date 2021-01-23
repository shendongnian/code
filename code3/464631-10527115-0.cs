    ...
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    using (StreamReader reader=new StreamReader(response.GetResponseStream()))
     {
     string line = reader.ReadToEnd();
     Console.WriteLine(line);
     }
