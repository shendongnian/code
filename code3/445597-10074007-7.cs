    int x = r.Next(questions.Count); 
    // intrebari is a variable of class 'question'
    string line = intrebari[x].text; 
    // find the colon
    int delimiter = line.IndexOf(':'); 
    // the image index is left of the colon
    int imageIndex = int.Parse(line.Substring(0, delimiter)); 
    // and the question itself is right of the colon
    string questionText = line.Substring(delimiter + 1); 
    // set the image in the picture box
    pictureBox1.Image = imageList1.Images[imageIndex]; 
