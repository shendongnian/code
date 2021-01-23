    var fb - new FacebookClient();
    fb.GetTaskAsync("4")
      .ContinueWith(t=> 
          if(!t.IsFaulted) {
              dynamic result = t.Result;
              var name = result.name;
          }
      );
