    string filePath = pathPlayer + player[id].name + "\\time.txt";
    string z = null;
    using (TextReader reader = File.OpenText(filePath))
    {
        z = reader.ReadLine();
    }
    string[] zsplit = z.Split(':');
    
    //Create a timespan from the values read from the .txt file
    TimeSpan fileTime = new TimeSpan(0, 0, int.parse(zsplit[0]), int.parse(zsplit[1]), int.parse(zsplit[2]));
    //Create a timespan from the values stored in the Textbox controls
    TimeSpan inputTime = new TimeSpan(0, 0, int.parse(timerMinute.Text), int.parse(timerSecond.Text), int.parse(timerMili.Text));
    
    //Check if the new TextBox time is faster than the time stored in the file
    if(inputTime < fileTime)
    {
        //new faster time, so update the file
        File.WriteAllText(filePath, inputTime.ToString("mm:ss:f"));
        newPersonalRecord = true;
    }
