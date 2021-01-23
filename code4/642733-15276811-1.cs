    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://192.168.2.17/android_connect/add_device.php");
    request.Method = "POST";
    string username = "CoolSops";
    string deviceId = "WindowsPhone";
    string batteryLevel = Windows.Phone.Devices.Power.Battery.GetDefault().RemainingChargePercent.ToString();
    string post_param = "username=" + username + "&device_id=" + deviceId + "&battery_level=" + batteryLevel;
    byte[] requestBody = System.Text.Encoding.UTF8.GetBytes(post_param);
    request.ContentLength = requestBody.Length;
    request.BeginGetRequestStream(
        result =>
        {
            using (var postStream = request.EndGetRequestStream(result))
            {
                postStream.Write(requestBody, 0, requestBody.Length);
                postStream.Close();
            }
            request.BeginGetResponse(
                (response) =>
                {
                    // Handle response here....
                },
                null);
        },
    request);
