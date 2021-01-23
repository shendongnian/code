    List<string> WaveSoundCollections = new List<string> { @"D:\Resources\International\Greetings.wav", @"D:\Resources\International\Good-Bye.wav" }; //Initializes a new Generic Collection of class List of type string and injecting TWO strings into the Generic Collection
    SoundPlayer NewPlayer = new SoundPlayer(); //Initializes a new SoundPlayer
    if (Client.Start) //Client refers to a particular Class that has Start and End as bool
    {
        NewPlayer.SoundLocation = WaveSoundCollections[0]; //Set the SoundLocation of NewPlayer to D:\Resources\International\Greetings.wav
        NewPlayer.Play(); //Plays the target Wave Sound file
    }
    else if (Client.End)
    {
        NewPlayer.SoundLocation = WaveSoundCollections[1]; //Set the SoundLocation of NewPlayer to D:\Resources\International\Good-Bye.wav
        NewPlayer.Play(); //Plays the target Wave Sound file
    }
