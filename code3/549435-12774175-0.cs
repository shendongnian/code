    /// Usage:
    ///   CheckLoginThen((bool result) => { CallWebServices(); });
    void CheckLoginThen(Action<bool> a) 
    {
      rji_ws.CheckLoginAsync(login_key,
        (sender, e) => 
        {
          if (e.Error != null)
          {
            MessageBox.Show("There was an error communicating with the server");
          }
          else
          {
            var result = e.Result;
            a(result);
          }
        }, 
        null);
    }
