    #pretend code#
    Global Variable -> string location;
    
    getGeoLoc += new geoLocCompleted;
    
    void geoLocCompleted(sender, e){
       location = e.result
       Timer time = new Timer():
       time.tick += OnTick;
}
    
    void onTick(send, e){
       if(e.result.length > 0)
          Show your results
       else
          Show loading dialog
    }
