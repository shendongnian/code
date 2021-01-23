    public List<List<string>> ReadOpenCalls(int relation)
        {
            IQAssemblyResolver.Initialize(@"C:\Program Files\.....");
            IQSDK IQSDK = new IQSDK();
            string loginTekst = IQSDK.Login("Administrator", "..", "..").GetResult();
            SDKRecordset inboundSet = IQSDK.CreateRecordset("R_ACTIONSCOPE", "CODE, DESCRIPTION, DATECREATED", "FK_RELATION = " + relation, "");
            var messages = new List<List<string>>();
            if (inboundSet != null && inboundSet.RecordCount > 0)
            {
                inboundSet.MoveFirst();
                 do
                 {
                    string code = inboundSet.Fields["CODE"].Value.ToString();
                    string desc = inboundSet.Fields["DESCRIPTION"].Value.ToString();
                    string date = inboundSet.Fields["DATECREATED"].Value.ToString();
                    messages.Add(new List<string> { code, desc, date});
                    inboundSet.MoveNext();
                 }
             while (!inboundSet.EOF);
                return messages;
            } 
            messages.Add("Error niet gelukt");
            return messages;// null;
        }
