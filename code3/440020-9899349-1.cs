        private static string getLowServerStoreDN_SnapIn(string ExchangeSite)
        {
            string strResult = string.Empty;
            RunspaceConfiguration rsConfig = RunspaceConfiguration.Create();
            PSSnapInException snapInException = null;
            PSSnapInInfo info = rsConfig.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.E2010", out snapInException);
            Runspace runspace = RunspaceFactory.CreateRunspace(rsConfig);
            try
            {
                runspace.Open();
                Command getMailbox = new Command("Get-MailboxDatabase");
                getMailbox.Parameters.Add(new CommandParameter("Status", null));
                Command sort = new Command("Sort-Object");
                sort.Parameters.Add("Property", "DatabaseSize");
                Pipeline commandPipeLine = runspace.CreatePipeline();
                commandPipeLine.Commands.Add(getMailbox);
                commandPipeLine.Commands.Add(sort);
                Collection<PSObject> getmailboxResults = commandPipeLine.Invoke();
                if (getmailboxResults.Count > 0)
                {
                    PSObject getMailboxResult = getmailboxResults[0];
                    strResult = getMailboxResult.Properties["Name"].Value.ToString();
                    //foreach (PSObject getMailboxResult in getmailboxResults)
                    //{
                    //    strResult = getMailboxResult.Properties["Name"].Value.ToString();
                    //}
                }
            }
            catch (ApplicationException e)
            {
                //Console.WriteLine(e.Message);
                throw new FaultException("function getLowServerStoreDN_SnapIn(" + ExchangeSite + "): " + e.Message,
                    FaultCode.CreateReceiverFaultCode("BadExchangeServer", "http://mysite.com"));
            }
            return strResult;
        }
