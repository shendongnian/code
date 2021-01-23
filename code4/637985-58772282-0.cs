    //the wav filename
    string file = "emergency_alarm_002.wav";
    
    //get the current assembly
    var assembly = System.Reflection.Assembly.GetExecutingAssembly();
    
    //load the embedded resource as a stream
    var stream = assembly.GetManifestResourceStream(string.Format("{0}.Resources.{1}", assembly.GetName().Name, file));
    
    //load the stream into the player
    var player = new System.Media.SoundPlayer(stream);
    
    //play the sound
    player.Play();
