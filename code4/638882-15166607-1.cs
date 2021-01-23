    using( HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse() )
    {
      if (WebResp.StatusCode == HttpStatusCode.OK)
                {
                    sAnswer = WebResp.GetResponseStream();
                    xDoc.Load(sAnswer);
                }
                else
                {
                    throw new Exception("No se obtuvo una respuesta satisfactoria del servidor\r\nHTTP Error Code:" + WebResp.StatusCode.ToString());
                }
    }
