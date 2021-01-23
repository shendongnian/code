    var lastMsgTime=Global.NewMsgTime;  
    while(true){     
         Thread.Sleep(300);  
         if(!Response.IsClientConnected||RequeGlobal.NewMsgTime!=lastMsgTime){
              lastMsgTime!=Global.NewMsgTime;
              break;  
         }  
    }   
