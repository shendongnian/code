    //"I also iterated through every line of the file, adding it to a list<>." Do this again.
    List<string> li = new List<string>()
    
    //However you create this string make sure you include the ":" at the end.
    string searchStr = "0xD176234F81150469:"; 
    private void button1_Click(object sender, EventArgs e)
    {
        foreach (string line in li)
        {
            string[] words;
            words = line.Split(' '); //{"[00000]", "0xD176234F81150469:", "foo"}
            if (temp[1] == searchStr)
            {
                list.Add(temp[2] + " (" + temp[1] + ")");
                // Sample output: "foo (0xD176234F81150469)"
            }
        }
    }
