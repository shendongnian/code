    private void parseIRCMessage(msg){
      lock(users)
      {
        if (msgType == "JOIN"){
            users.Add(user);
        }
        else if (msgType == "PART"){
            users.Remove(user);
        }
      }
    }
    private void doWork(){
        while (true) {
            if (streamOnline() && handOutTime()){
                handOutCurrency();
            }
        Thread.Sleep(60000);
        }
    }
    private void handOutCurrency(){
      lock(users)
      {
        foreach (String user in users) {
            database.AddCurrency(user, 1);
        }
      }
    }
