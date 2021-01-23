            GetMacAddressfromIP macadd = new GetMacAddressfromIP();
            if (userAgent.Contains("iphone;"))
            {
                // iPhone                
                Label1.Text = userAgent;
                Label2.Text = userAgent1;
                string Getmac = macadd.GetMacAddress(userAgent1);
                Label3.Text = Getmac;
            }
            else if (userAgent.Contains("ipad;"))
            {
                // iPad
                Label1.Text = userAgent;
                Label2.Text = userAgent1;
                string Getmac = macadd.GetMacAddress(userAgent1);
                Label3.Text = Getmac;
            }
            else
            {
                Label1.Text = userAgent;
                Label2.Text = userAgent1;
                string Getmac = macadd.GetMacAddress(userAgent1);
                Label3.Text = Getmac;
            }
