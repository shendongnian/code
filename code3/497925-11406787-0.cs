        NetworkClass 
        {
           RegisterChannel(objUsingChannel,typeOfChannel, callbackForChannel, expectedReturnType){/*...*/};
    
           PushChannelMsg(channelID, dataToSend)
    
           ReceiveMessageFromNetwork(msg){  Read data from network, which also contains channelID, and send it to any matching channelID}  
           //If there is no channel registered for a data that is received,  just ignore it
        }
    EnemyTurretObject
    {
       //Register the rotation channel and listen for rotation changes
       NetworkClass.RegisterChannel(this, channels.TurretRotated + this.ID, callback=HandleTurretRotated, doubleReturnType)
       HandleTurretRotated(double rot)
       {  rotate the turret  }
    }
    FriendlyTurretObject
    {
       //Register two channels that we'll send data across
       NetworkClass.RegisterChannel(this, channels.TurretFired + this.ID, callback=null, MissleFiredData)
       NetworkClass.RegisterChannel(this, channels.TurretRotated + this.ID, callback=null, doubleDataType)
       FireMissle()
        {
           NetworkClass.PushChannelMsg(channels.TurretFired + this.ID, new MissleFiredData(x,y)) 
        }
        
        RotateTurret()
        {
          NetworkClass.PushChannelMsg(channels.TurretRotated + this.ID, newTurretRotationValue) 
        }
    }
