    if (result != null)
    {
        oSyncContext.Post(new System.Threading.SendOrPostCallback(
                delegate(object state)
                {
                    IBackgroundChangeClient client = (state as object[])[0] as IBackgroundChangeClient
                    //i dont konw the type of this
                    var test = (state as object[])[1];
                    string sText = (test  == 0x00 ? "HIGH" : "LOW");
                    client.SetText(sText);
                    if (test == 0x00)
                    {
                        client.SetButtonsBackground(Color.Green);
                    }
                    else
                    {
                        client.SetButtonsBackground(Color.Red);
                    }
                }), new object[] { oBackgroundChangeClient, result[4]});
    }
