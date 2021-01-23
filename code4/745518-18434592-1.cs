    string mcURLData = "Error";
    using (WebClient client = new WebClient()) // Get Data from Minecraft with username and password
    {
        this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Connecting to Minecraft.net..."; }));
        try
        {
            System.Collections.Specialized.NameValueCollection urlData = new System.Collections.Specialized.NameValueCollection();
            urlData.Add("user", "UserName");
            urlData.Add("password", "MYPa22w0rd");
            urlData.Add("version", "13");
            byte[] responsebytes = client.UploadValues("https://login.minecraft.net", "POST", urlData);
            mcURLData = Encoding.UTF8.GetString(responsebytes);
        }
        catch
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                mcURLData = "Internet Disconnected.";
            }
            else
            {
                mcURLData = "Can't connect to login.minecraft.net.";
            }
        }
    }
