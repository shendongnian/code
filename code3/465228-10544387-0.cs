    TextReader sr = new StreamReader(textBox1.Text); 
    TextReader sr2 = new StreamReader(textBox2.Text); 
    
    string contents = sr.ReadToEnd(); 
    string contents2 = sr2.ReadToEnd(); 
    
    string[] myArray = contents.Split(new Char [] {' ', ','}); 
    string[] myArray2 = contents2.Split(new Char [] {' ', ','}); 
    string[] joinednames = myArray.Zip(myArray2, (x, y) => x + " " + y).ToArray();
    foreach(string element in joinednames)
    {
        Debug.WriteLine(element);
    }
