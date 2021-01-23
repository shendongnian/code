    class Facebook {
       ...
       public string GetAccessToken(string username, string password) {
          // can throw WebException if can't connect to FB
          this.Connect(); 
          // returns null token if not a Facebook user
          if (!this.IsUser(username)) return null;
          
          // can throw ArgumentException if password is wrong
          var fbInfo = this.GetInfo(username, password);
          return fbInfo.AccessToken;
       }
       ...
    }
    class Page {
       void Page_Load(object sender, EventArgs e) {
          var fb = new Facebook();
    
          string accessToken;
          try {
             accessToken = fb.GetAccessToken(this.User.Name, this.txtPassword.Text);
          } catch (WebException ex) {
             Log(ex);
             this.divError.Text = "Sorry, Facebook is down";
             // continue processing without Facebook
          } catch (ArgumentException ex) {
             // Don't log - we don't care
             this.divError.Text = "Your password is invalid";
             // stop processing, let the user correct password
             return;
          } catch (Exception ex) {
             Log(ex);
             // Unknown error. Stop processing and show friendly message
             throw;
          }
          if (!string.IsNullOrEmpty(accessToken)) {
             // enable Facebook integration 
             this.FillFacebookWallPosts(accessToken);
          } else {
             // disable Facebook integration
             this.HideFacebook();
          }
       }
    }
