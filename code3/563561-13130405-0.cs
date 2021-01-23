    HttpWebRequest  request  = (HttpWebRequest)
    WebRequest.Create(url);
    HttpWebResponse response = (HttpWebResponse)
    request.GetResponse();
    Stream resStream = response.GetResponseStream();
    string tempString = null;
    int count = 0;
    do
    {
        // fill the buffer with data
        count = resStream.Read(buf, 0, buf.Length);
        // make sure we read some data
        if (count != 0)
        {
            // translate from bytes to ASCII text
            tempString = Encoding.ASCII.GetString(buf, 0, count);
            // continue building the string
            sb.Append(tempString);
        }
    }
    while (count > 0); // any more data to read?
    String text = sb.ToString();
    if(text == "1")
        Console.Write("Yes");
    else
        Console.Write("No");
