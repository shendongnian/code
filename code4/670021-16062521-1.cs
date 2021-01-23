    //Define your connection
    LdapConnection ldapConnection = new LdapConnection("123.456.789.10:389");
    
    try
    {
          //Authenticate the username and password
          using (ldapConnection)
          {
              //Pass in the network creds, and the domain.
              var networkCredential = new NetworkCredential(Username, Password, Domain);
              //Since we're using unsecured port 389, set to false. If using port 636 over SSL, set this to true.
              ldapConnection.SessionOptions.SecureSocketLayer = false;
              ldapConnection.SessionOptions.VerifyServerCertificate += delegate { return true; };
              //To force NTLM\Kerberos use AuthType.Negotiate, for non-TLS and unsecured, use AuthType.Basic
              ldapConnection.AuthType = AuthType.Basic;
              ldapConnection.Bind(networkCredential);
          }
          catch (LdapException ldapException)
          {
              //Authentication failed, exception will dictate why
          }
    }
