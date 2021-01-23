     public static DirectoryService Service { get; private set; }
        private static IAuthenticator CreateAuthenticator()
        {
            var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description);
            provider.ClientIdentifier = <myClientId>;
            provider.ClientSecret = <myClientSecret>";
            return new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthentication);
        }
        private static IAuthorizationState GetAuthentication(NativeApplicationClient client)
        {
            // You should use a more secure way of storing the key here as
            // .NET applications can be disassembled using a reflection tool.
            const string STORAGE = "bergstedts.directoryservice";
            const string KEY = "y},drdzf11x9;87";
            string scope = DirectoryService.Scopes.AdminDirectoryUser.GetStringValue();
            // Check if there is a cached refresh token available.
            IAuthorizationState state = AuthorizationMgr.GetCachedRefreshToken(STORAGE, KEY);
            if (state != null)
            {
                try
                {
                    client.RefreshToken(state);
                    return state; // Yes - we are done.
                }
                catch (DotNetOpenAuth.Messaging.ProtocolException ex)
                {
                    CommandLine.WriteError("Using existing refresh token failed: " + ex.Message);
                }
            }
            // Retrieve the authorization from the user.
            state = AuthorizationMgr.RequestNativeAuthorization(client, scope);
            AuthorizationMgr.SetCachedRefreshToken(STORAGE, KEY, state);
            return state;
        }
    private void CreateUserBtn_Click(object sender, EventArgs e)
        {
            // Create Service
            DirectoryService m_serviceUser = new DirectoryService(new BaseClientService.Initializer()
            {
                Authenticator = CreateAuthenticator(),
                ApplicationName = "newuser"
            });           
            // Store data from TextBoxes in form to User-object
            User newuserbody = new User();
            newuserbody.Name = new UserName();
            newuserbody.PrimaryEmail = UserNameTextBox.Text + "@" + DomainTextBox.Text;
            newuserbody.Name.GivenName = GivenNameTextBox.Text;
            newuserbody.Name.FamilyName = FamilyNameTextBox.Text;           
            newuserbody.Password = PasswordTextBox.Text;
            
            // Create user and store the newly created user in ccreateduser
            User createduser = m_serviceUser.Users.Insert(newuserbody).Execute();
            // display Userdata
            CreatedUserLbl.Text = "User : " + createduser.PrimaryEmail + " has been created!";   
        
            // Clear inputfields (except for domain)
            UserNameTextBox.Text = "";
            GivenNameTextBox.Text = "";
            FamilyNameTextBox.Text = "";
            PasswordTextBox.Text = "";
        }
