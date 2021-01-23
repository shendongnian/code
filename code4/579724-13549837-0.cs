     using System.Globalization;
    //...
     DateTime _datetime = DateTime.Now;
    string _formattedDateTime = _datetime.ToUniversalTime().ToString("s", 
    DateTimeFormatInfo.InvariantInfo) + "Z";
