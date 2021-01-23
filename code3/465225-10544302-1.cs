    TextReader sr = new StreamReader(textBox1.Text); 
    TextReader sr2 = new StreamReader(textBox2.Text); 
    
    string contents = sr.ReadToEnd(); 
    string contents2 = sr2.ReadToEnd(); 
    
    string[] myArray = contents.Split(new Char [] {' ', ','}); 
    string[] myArray2 = contents2.Split(new Char [] {' ', ','}); 
    System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
    
    foreach (string element1 in myArray) 
    { 
        foreach (string element2 in myArray2) 
        { 
            sb.Append(element1); 
            sb.Append(" " + element2); 
            Debug.WriteLine(sb.ToString()); 
        } 
    } 
    
    string str = sb.ToString(); 
    Debug.WriteLine(str); 
    
    //MessageBox.Show(sb.ToString); 
