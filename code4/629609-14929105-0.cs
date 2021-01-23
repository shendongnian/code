        public class Transaction
        {
            public string Ticker {get; set;}
            public string Action {get; set;}
            public string Date {get; set;}
            public int NumShares {get; set;}
        }
        private List<Transaction> getTransactionsFromFile(string filename)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filename);
            List<Transaction> tranList = new List<Transaction>();
            foreach (XmlNode x in xDoc)
            {
                if (x.Name == "stocks")
                {
                    foreach (XmlNode y in x.ChildNodes)
                    {
                        if (y.Name == "transaction")
                        {
                            Transaction tempTran = new Transaction();
                            foreach (XmlNode z in y.ChildNodes)
                            {
                                if (z.Name == "ticker")
                                {
                                    tempTran.Ticker= z.InnerText;
                                }
                                if (z.Name == "action")
                                {
                                    tempTran.Action= z.InnerText;
                                }
                                if (z.Name == "date")
                                {
                                    tempTran.Date = z.InnerText;
                                }
                                if (z.Name == "shares")
                                {
                                    tempTran.NumShares = int.Parse(z.InnerText);
                                }
                                if (z.Name == "PassOutputToChildSteps")
                            }
                            //add the constructed Transaction Object to the Transaction List...
                            tranList.Add(tempTran);
                        }
                    }
                }
            }
            return tranList;
        }
