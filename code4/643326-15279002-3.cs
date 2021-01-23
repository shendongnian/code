    // create reader & open file
    TextReader tr = new StreamReader("SavedGame.txt");
    
    // read lines of text
    string xCoordString = tr.ReadLine();
    string yCoordString = tr.ReadLine();
    
    //Convert the strings to int
    xCoordinate = Convert.ToInt32(xCoordString);
    yCoordinate = Convert.ToInt32(yCoordString);
    
    // close the stream
    tr.Close();
