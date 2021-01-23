    string z = null;
    using (TextReader reader = File.OpenText(pathPlayer + player[id].name + "\\time.txt"))
    {
        z = reader.ReadLine();
    }
    string[] zsplit = z.Split(':');
    
    TimeSpan fileTime = new TimeSpan(0, 0, int.parse(zsplit[0]), int.parse(zsplit[1]), int.parse(zsplit[2]));
    TimeSpan inputTime = new TimeSpan(0, 0, int.parse(timerMinute.Text), int.parse(timerSecond.Text), int.parse(timerMili.Text));
    
    if(fileTime < inputTime)
    {
        File.WriteAllText(pathPlayer + player[id].name + "\\time.txt", timerMinute.Text + ":" + timerSecond.Text + ":" + timerMili.Text);
        newPersonalRecord = true;
    }
