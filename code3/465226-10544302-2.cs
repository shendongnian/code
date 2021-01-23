    TextReader sr = new StreamReader(textBox1.Text); 
    TextReader sr2 = new StreamReader(textBox2.Text); 
    
    string contents = sr.ReadToEnd(); 
    string contents2 = sr2.ReadToEnd(); 
    
    string[] myArray = contents.Split(new Char [] {' ', ','}); 
    string[] myArray2 = contents2.Split(new Char [] {' ', ','}); 
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    
    var joinednames = myArray.Zip(myArray2, (x, y) => x + " " + y).ToList();
    
    foreach (string str in joinednames)
    {
        Debug.WriteLine(str);
    }
