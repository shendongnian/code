            XDocument xDoc = XDocument.Load("XMLFile1.xml");
            List<string> EXPRs = xDoc.Element("RESPONSE").Elements("EXPR").Select( e => e.Value).ToList();
            List<XElement> CONVERSIONs = xDoc.Element("RESPONSE").Elements("CONVERSION").ToList();
            for(int i=0; i<EXPRs.Count; i++)
            {
                var currrates = new Rates();
                currrates.Currency_ID = EXPRs[i];
                currrates.DATE = CONVERSIONs[i].Element("DATE").Value;
                Console.WriteLine(currrates.Currency_ID + currrates.Sell_Rate);
                Console.ReadKey();
            }
