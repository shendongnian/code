    string[] mysplit = Tool_Tip.Split(s.Split(new string[]{"Controls:"}, StringSplitOptions.RemoveEmptyEntries);
    string controls = mysplit[1].Substring(0); //ON_OFF=On;BRIGHTNESS=NONE
    string[] eachSettings = controls.Split(';');
    //eachSettings[0] = ON_OFF=ON
    //eachSettings[1] = BRIGHTNESS=NONE
