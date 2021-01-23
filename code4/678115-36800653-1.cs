    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web.Script.Serialization;
    public class AndroidGcmPushNotification
    {
    private readonly string _apiAccessKey;
    private readonly string[] _registrationIds;
    private readonly string _message;
    private readonly string _title;
    private readonly string _subtitle;
    private readonly string _tickerText;
    private readonly bool _vibrate;
    private readonly bool _sound;
    public AndroidGcmPushNotification(string apiAccessKey, string[] registrationIds, string message, string title = "",
        string subtitle = "", string tickerText = "", bool vibrate = true, bool sound = true )
    {
        _apiAccessKey = apiAccessKey;
        _registrationIds = registrationIds;
        _message = message;
        _title = title;
        _subtitle = subtitle;
        _tickerText = tickerText;
        _vibrate = vibrate;
        _sound = sound;
    }
    public string SendGcmNotification()
    {
        //MESSAGE DATA
        GcmPostData data = new GcmPostData()
        {
            message = _message,
            title = _title,
            subtitle = _subtitle,
            tickerText = _tickerText,
            vibrate = _vibrate,
            sound = _sound
        };
        //MESSAGE FIELDS 
        GcmPostFields fields = new GcmPostFields();
        fields.registration_ids = _registrationIds;
        fields.data = data;
        //SERIALIZE TO JSON 
        JavaScriptSerializer jsonEncode = new JavaScriptSerializer();
        //CONTENTS
        byte[] byteArray = Encoding.UTF8.GetBytes(jsonEncode.Serialize(fields));
        //REQUEST
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
        request.Method = "POST";
        request.KeepAlive = false;
        request.ContentType = "application/json";
        request.Headers.Add($"Authorization: key={_apiAccessKey}");
        request.ContentLength = byteArray.Length;
        Stream dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        //SEND REQUEST
        try
        {
            WebResponse response = request.GetResponse();
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseLine = reader.ReadToEnd();
                reader.Close();
                return responseLine;
            }
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
    private class GcmPostFields
    {
        public string[] registration_ids { get; set; }
        public GcmPostData data { get; set; }
    }
    private class GcmPostData
    {
        public string message { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string tickerText { get; set; }
        public bool vibrate { get; set; }
        public bool sound { get; set; }
    }
    }
