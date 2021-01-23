    public int getDistance(string origin, string destination)
    {
        System.Threading.Thread.Sleep(1000);
        int distance = 0;
        //string from = origin.Text;
        //string to = destination.Text;
        string url = "http://maps.googleapis.com/maps/api/directions/json?origin=" + origin + "&destination=" + destination + "&sensor=false";
        string requesturl = url;
        //string requesturl = @"http://maps.googleapis.com/maps/api/directions/json?origin=" + from + "&alternatives=false&units=imperial&destination=" + to + "&sensor=false";
        string content = fileGetContents(requesturl);
        JObject o = JObject.Parse(content);
        try
        {
            distance = (int)o.SelectToken("routes[0].legs[0].distance.value");
            return distance;
        }
        catch
        {
            return distance;
        }
        return distance;
        //ResultingDistance.Text = distance;
    }
        protected string fileGetContents(string fileName)
        {
            string sContents = string.Empty;
            string me = string.Empty;
            try
            {
                if (fileName.ToLower().IndexOf("http:") > -1)
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    byte[] response = wc.DownloadData(fileName);
                    sContents = System.Text.Encoding.ASCII.GetString(response);
                }
                else
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                    sContents = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch { sContents = "unable to connect to server "; }
            return sContents;
        }
