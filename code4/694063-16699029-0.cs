    using System.Net.Http; //this is for HTTPClient class
    using Windows.UI.Popups //this is for Messagebox popup.
    private async void getResponse()
            {
                try
                {
                    HttpClient htClient = new HttpClient();
                    string webUri = "www.google.com" //replace ur request web URI here
                    string result = await htClient.GetStringAsync(webUri);
                    //Form here you can code to extract the web response.
                    //result is the web response string
                }
                catch (Exception c)
                {
                    messageBox(c.Message);
    
                }
            }
    //this is the method to show messagebox popup
    protected async void messageBox(string msg)
            {
                var msgDlg = new Windows.UI.Popups.MessageDialog(msg);
                msgDlg.DefaultCommandIndex = 1;
                await msgDlg.ShowAsync();
            }
