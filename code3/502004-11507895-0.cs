    void ParseFiles(string[] files, ProcessingDescription description) {
      foreach(string file in files) {
        if(!file.IsValid()) { //uses an extension method
          LogFailure(file, "Your Message"); //use the appropriate API
          continue;
        }
        try {    
          DoComplicatedProcessing(file, description);
        }
        catch(Exception e) {
          LogFailure(file, e);
        }
      }
      DisplayResult();
    }
