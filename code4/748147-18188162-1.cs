    string z = null;
    using (TextReader reader = File.OpenText(pathPlayer + player[id].name + "\\time.txt"))
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
        File.WriteAllText(pathPlayer + player[id].name + "\\time.txt", timerMinute.Text + ":" + timerSecond.Text + ":" + timerMili.Text);
        newPersonalRecord = true;
    }
