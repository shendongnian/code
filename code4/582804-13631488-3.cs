         <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> <Services.WebMethod(EnableSession:=True)> _
         Public Shared Function getAccIDFromSocialAuthSession() As Object
              Dim db As SqlDatabase = Connection.connection
              Dim accID As Integer
              If SocialAuthUser.IsLoggedIn Then
                  Using cmd As SqlCommand = db.GetSqlStringCommand("SELECT AccountID FROM UserAccounts WHERE FBID=@fbID")
                      db.AddInParameter(cmd, "fbID", SqlDbType.VarChar, SocialAuthUser.GetCurrentUser.GetProfile.ID)
                      accID = db.ExecuteScalar(cmd)
                  End Using
              End If
    
            Return accID
        End Function
