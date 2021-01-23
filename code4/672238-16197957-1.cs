        public void SendPush()
        {
            try
            {
                client.BaseUrl = "https://api.cloud.appcelerator.com";
                request.Resource = "/v1/push_notification/notify.json?key={appkey}";
                request.Method = Method.POST;
                request.AddUrlSegment("appkey", "key");
                request.AddParameter("channel", "alert");
                request.AddParameter("payload", "{ \"title\" : \"notificación\", \"badge\" : 1, \"alert\" : \"alerta: Sismo detectado en: " + direccion + " proximo arribo de sismo a la ciudad de mexico\", \"sound\" : \"default\"}");
                var response = client.Execute(request);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Message " + ex.Message + " \n Inner Exception " + ex.InnerException + " \n Stack Trace" + ex.StackTrace);
            }
        }
