    public static void sendSMS(string Recepient, string Message)
    {
        //Recepient is the cellno in string format
        StringBuilder sb = new StringBuilder();
        sb.Append("http://www.mymobileapi.com/api5/http5.aspx?");
        sb.Append("Type=sendparam");
        sb.Append("&username={yourusername}");//add your username here
        sb.Append("&password={yourpassword}");//add your password here
        sb.AppendFormat("&numto={0}", Recepient);
        string message = HttpUtility.UrlEncode(Message, ASCIIEncoding.ASCII);
        sb.AppendFormat("&data1={0}", message);
        try
        {
            ////Create the request and send data to the SMS Gateway Server by HTTP connection
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(sb.ToString());
            //Get response from the SMS Gateway Server and read the answer
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
        }
        catch (Exception ex)
        {
                 
        }
    }
