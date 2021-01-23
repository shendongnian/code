    using System;
    using System.IO;
    using System.Net;
    
    public class SendGridTest
    {
      static public void Main ()
      {
        string api_user = "your_sendgrid_username";
        string api_key = "your_sendgrid_key";
        string toAddress = "john.doe@example.com";
        string toName = "John Doe";
        string subject = "A message from SendGrid";
        string text = "Delivered by your friends at SendGrid.";
        string fromAddress = "swift@sendgrid.com";
    
        string parameters = "api_user=" + api_user + "&api_key=" + api_key + "&to=" + toAddress + "&toname=" + toName + "&subject=" + subject + "&text=" + text + "&from=" + fromAddress;
        string url = "https://sendgrid.com/api/mail.send.json";
    
        try
        {
          //Create Request
          HttpWebRequest myHttpWebRequest = (HttpWebRequest) HttpWebRequest.Create(url);
          myHttpWebRequest.Method = "POST";
          myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
    
          StreamWriter streamWriter = new StreamWriter(myHttpWebRequest.GetRequestStream());
    
          streamWriter.Write(parameters);
          streamWriter.Flush();
          streamWriter.Close();
    
          HttpWebResponse httpResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
          StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream());
    
          string result = streamReader.ReadToEnd();
          Console.WriteLine(result);
        }
        catch(WebException ex)
        {
          HttpWebResponse response = (HttpWebResponse)ex.Response;
          StreamReader streamReader = new StreamReader(response.GetResponseStream());
    
          string result = streamReader.ReadToEnd();
          Console.WriteLine(result);
        }
      }
    }
