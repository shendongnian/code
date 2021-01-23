    List<string> textLines;
    string Name01 = NameBox.Text;
    string Name02 =FamilyNameBox.Text;
    string Name03 = PhoneBox.Text;
    string Informtion = Name01 + Name02 + Name03;   
    textLines.Add(Information);
    // add more lines if you want.
    File.WriteAllLines(fileName, textLines);
