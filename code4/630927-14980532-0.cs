     string userDn = @"cn=Feat Studentl+umanroleid=302432,ou=Faculty of Engineering & Physical Sciences Administration,ou=Faculty of Engineering & Physical Sciences,ou=People,o=University of TestSite,c=GB";
     string basicUrl = @"surinam.testsite.ac.uk:636";
      var ldapConnection = new LdapConnection(basicUrl);
      ldapConnection.AuthType = AuthType.Basic;
      LdapSessionOptions options = ldapConnection.SessionOptions;
      options.ProtocolVersion = 3;
      options.SecureSocketLayer = true;
      NetworkCredential credential = new NetworkCredential(userDn, password);                             
      ldapConnection.Credential = credential;
      try
      {
          ldapConnection.Bind();
          Console.WriteLine("bind succeeded ");
      }
      catch (LdapException e)
      {
          if (e.ErrorCode == 49)
          {
               Console.WriteLine("bind failed ");
          }
          else
          {
              Console.WriteLine("unexpected result " + e.ErrorCode);
          }
      }
      catch (DirectoryOperationException e)
      {
          Console.WriteLine("unexpected error " + e.Message);
      }
