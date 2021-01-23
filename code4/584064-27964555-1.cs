    public class OAuthTest
    {
        const String ClientSecretsFile = @"\\client_secrets.json";
    
        bool m_Init;
        OAuth2Parameters param = new OAuth2Parameters();
    
        public OAuthTest()
        {
            System.Diagnostics.Debug.WriteLine("Calling: AuthGoogleDataInterface()");
            m_Init = AuthGoogleDataInterface();
            if (m_Init)
            {
                GOAuth2RequestFactory requestFactory = new GOAuth2RequestFactory(null, "My App User Agent", this.param);
                //requestFactory.CustomHeaders.Add(string.Format("Authorization: Bearer {0}", credential.Token.AccessToken));
                var service = new SpreadsheetsService("MyService");
                service.RequestFactory = requestFactory;
                SpreadsheetQuery query = new SpreadsheetQuery();
    
                // Make a request to the API and get all spreadsheets.
                SpreadsheetFeed feed = service.Query(query);
    
                // Iterate through all of the spreadsheets returned
                foreach (SpreadsheetEntry entry in feed.Entries)
                {
                    // Print the title of this spreadsheet to the screen
                    System.Diagnostics.Debug.WriteLine(entry.Title.Text);
                }
            }
            System.Diagnostics.Debug.WriteLine(m_Init);
        }
    
        private bool AuthGoogleDataInterface()
        {
            bool b_success;
            try
            {
                Console.WriteLine("New User Credential");
                // New User Credential
                UserCredential credential;
                using (var stream = new FileStream(ClientSecretsFile, FileMode.Open, FileAccess.Read))
                {
                    GoogleClientSecrets GCSecrets = GoogleClientSecrets.Load(stream);
                    string[] ArrScope = new[] { "https://spreadsheets.google.com/feeds", "https://docs.google.com/feeds" };
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GCSecrets.Secrets,
                        ArrScope,
                        "user", CancellationToken.None,
                    new FileDataStore("My.cal")).Result;
                    // put the Information generated for the credentials object into the OAuth2Parameters-Object to access the Spreadsheets
                    this.param.ClientId = GCSecrets.Secrets.ClientId; //CLIENT_ID;
                    this.param.ClientSecret = GCSecrets.Secrets.ClientSecret; //CLIENT_SECRET;
                    this.param.RedirectUri = "urn:ietf:wg:oauth:2.0:oob"; //REDIRECT_URI;
                    this.param.Scope = ArrScope.ToString();
                    this.param.AccessToken = credential.Token.AccessToken;
                    this.param.RefreshToken = credential.Token.RefreshToken;
                }
    
                System.Diagnostics.Debug.WriteLine("AuthGoogleDataInterface: Success");
                b_success = true;
            }
            catch (Exception e)
            {
                string cs_err;
                cs_err = e.Message;
                System.Diagnostics.Debug.WriteLine(cs_err);
                System.Diagnostics.Debug.WriteLine(e.Source);
                System.Diagnostics.Debug.WriteLine("AuthGoogleDataInterface: Fail");
                b_success = false;
                throw;
            }
            return b_success;
        }
    }
