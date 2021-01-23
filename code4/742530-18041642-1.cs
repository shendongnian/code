    string getWord(int which)
    {
        string readed = "";
        using (Systen.IO.StreamReader read = new System.IO.StreamReader("PATH HERE"))
        {
           readed = read.ReadToEnd(); 
        }
        string[] toReturn = readed.Split('\n');
        return toReturn[which - 1];
    }
