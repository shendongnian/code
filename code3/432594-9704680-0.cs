    // Add references:
    //      DotNetOpenAuth.dll
    //      Google.Apis.dll
    //      Google.Apis.Authentication.OAth2.dll
    //      Newtonsoft.Json.Net35.dll
    // plus, add references for whichever Google App(s) you want
    //      Google.Apis.Calendar.v3.dll
    // form contains at least the following:
    //      button1: Button, start the authentication process
    //      authCode: TextBox, to recive the auth code from Google
    //      button2: Button, complete the authentication prop
    //      textBox2: TextBox, multi-line, to display status message and output
    // in addition to the libraries required for any forms program, use:
    using System.Diagnostics;
    using DotNetOpenAuth.OAuth2;
    using Google.Apis.Authentication.OAuth2;
    using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
    using Google.Apis.Calendar.v3;
    using Google.Apis.Calendar.v3.Data;
    using Google.Apis.Util;
    // methods not related to authentication deleted for space
    namespace GoogleCal
    {
        public partial class GoogleCal : Form
        {
            private static String NL = Environment.NewLine;
            private static IAuthorizationState state;
            private static NativeApplicationClient provider;
            private static OAuth2Authenticator<NativeApplicationClient> auth;
            private static CalendarService calService;
            private void button1_Click(object sender, EventArgs e)
            {
                // clicked to initiate authentication process
                // provider and state are declared above as private static
    
                provider = new NativeApplicationClient(GoogleAuthenticationServer.Description);
                provider.ClientIdentifier = "<my id>.apps.googleusercontent.com";
                provider.ClientSecret = "<my secret>";
                // next line changes if you want to access something other than Calendar
                state = new AuthorizationState(new[] { CalendarService.Scopes.Calendar.GetStringValue() });
                state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);
                Uri authUri = provider.RequestUserAuthorization(state);
    
                Process.Start(authUri.ToString());
            }
            private void button2_Click(object sender, EventArgs e)
            {
                // clicked after Google code is pasted into TextBox to complete authentication process
    
                // auth and calService are declared above as private static
                auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthorization);
            
                // create the service object to use in other methods
                calService = new CalendarService(auth);
                textBox2.AppendText("Ready" + NL);
                textBox2.Update();
            }
            private IAuthorizationState GetAuthorization(NativeApplicationClient arg)
            {
                // state is declared above as private static
                // authCode is a TextBox on the form
                return arg.ProcessUserAuthorization(authCode.Text, state);
            }
        }
    }
