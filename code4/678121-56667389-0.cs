      using System;
        using System.Net;
        using System.Web.Http;
        using System.Web.Script.Serialization;
        using System.Configuration;
        using System.IO;
        
        namespace pushios.Controllers
            {
        
            public class HomeController : ApiController
                {
                    [HttpGet]
        
            [Route("sendmessage")]
        
                    public IHttpActionResult SendMessage()
                  {
                        var data = new {
                            to = "Device Token",
                            data = new
                            {
                               //To be adding your json data
                                body="Test",
                                confId= "",
                                pageTitle= "test",
                                pageFormat= "",
                                dataValue= "",
                                title= "C#",
                                webviewURL= "",
                                priority = "high",
                                notificationBlastID = "0",
                                status = true
                            }
                        };
                        SendNotification(data);
                        return Ok();
                    }
                    public void SendNotification(object data)
                    {
                        var Serializer = new JavaScriptSerializer();
                        var json = Serializer.Serialize(data);
                        Byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(json);
        
                        SendNotification(byteArray);
                    }
                    public void SendNotification(Byte[] byteArray)
                    {
        
                        try
                        {
                            String server_api_key = ConfigurationManager.AppSettings["SERVER_API_KEY"];
                            String senderid = ConfigurationManager.AppSettings["SENDER_ID"];
        
                            WebRequest type = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                            type.Method = "post";
                            type.ContentType = "application/json";
                            type.Headers.Add($"Authorization: key={server_api_key}");
                            type.Headers.Add($"Sender: id={senderid}");
        
                            type.ContentLength = byteArray.Length;
                            Stream datastream = type.GetRequestStream();
                            datastream.Write(byteArray, 0, byteArray.Length);
                            datastream.Close();
        
                            WebResponse respones = type.GetResponse();
                            datastream = respones.GetResponseStream();
                            StreamReader reader = new StreamReader(datastream);
        
                            String sresponessrever = reader.ReadToEnd();
                            reader.Close();
                            datastream.Close();
                            respones.Close();
        
                        }
                        catch (Exception)
                        {
                            throw;
                        }
        
                    }
                }
            }
            ```
