    foreach (RecognizerInfo ri in SpeechRecognitionEngine.InstalledRecognizers())
    {
        Debug.WriteLine(String.Format("Id={0}, Name={1}, Description={2}, Culture={3}", ri.Id, ri.Name, ri.Description, ri.Culture));
        foreach(string key in ri.AdditionalInfo.Keys)
        {
            Debug.WriteLine(string.Format("{0} = {1}", key, ri.AdditionalInfo[key]));
        }
        Debug.WriteLine("-");
    }
