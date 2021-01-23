    myLabel.Text = "loading...<br />";
    using (WebClient wc = new WebClient())
    {
        wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler((sender2, e2) =>
        {
            var xmlElm = XElement.Parse(e2.Result);
            var status = (from elm in xmlElm.Descendants()
                where elm.Name == "status"
                select elm).FirstOrDefault();
            if (status.Value.ToLower() == "ok")
            {
                var res = (from elm in xmlElm.Descendants()
                    where elm.Name == "formatted_address"
                    select elm).FirstOrDefault();
                myLabel.Text = res.Value;
            }
            else
            {
                 myLabel.Text = "Bad status: " + status.Value;
            }
        });
        wc.DownloadStringAsync(new Uri(requestUri));
    }
