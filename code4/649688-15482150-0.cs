            Uri u = new Uri(url);
            ServicePoint sp = ServicePointManager.FindServicePoint(u);
            string groupName = Guid.NewGuid().ToString();
            HttpWebRequest req = HttpWebRequest.Create(u) as HttpWebRequest;
            req.ConnectionGroupName = groupName;
            using (WebResponse resp = req.GetResponse())
            {
                
            }
            sp.CloseConnectionGroup(groupName);
            byte[] key = sp.Certificate.GetPublicKey();
            return key;
