    void SendBatteryLevel(IAsyncResult asynchronousResult)
    {
        HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
        using (var postStream = request.EndGetRequestStream(asynchronousResult))
        {
            string username = "CoolSops";
            string deviceId = "WindowsPhone";
            string batteryLevel = Windows.Phone.Devices.Power.Battery.GetDefault().RemainingChargePercent.ToString();
            string post_param = "username=" + username + "&device_id=" + deviceId + "&battery_level=" + batteryLevel;
            
            byte[] requestBody = System.Text.Encoding.UTF8.GetBytes(post_param);
            postStream.Write(requestBody, 0, requestBody.Length);
            postStream.Close();
            request.ContentLength = requestBody.Length;
        }
        request.BeginGetResponse(....);
    }
