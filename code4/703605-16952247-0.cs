    ConcurrentQueue<string> toAdd = new ConcurrentQueue<string>();
    ConcurrentQueue<string> toRemove = new ConcurrentQueue<string>();
    private void parseIRCMessage(msg){
        if (msgType == "JOIN"){
            toAdd.Enqueue(user);
        }
        else if (msgType == "PART"){
            toRemove.Enqueue(user);
        }
    }
    private void doWork(){
        while (true) {
            string user;
            while (toAdd.TryDequeue(out user)) {
                users.Add(user);
            }
            while (toRemove.TryDequeue(out user)) {
                users.Remove(user);
            }
            if (streamOnline() && handOutTime()){
                handOutCurrency();
            }
            Thread.Sleep(60000);
        }
    }
