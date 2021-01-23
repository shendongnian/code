    List<InputFileConvertor> inputList = new ......
    string[] lines =System.IO.File.ReadAllLines(@"C:\Data.txt");
    foreach(String line in lines)
    {
       InputFileConvertor lineInput = new InputFileConvertor();
       lineInput.Name = line.Substring(nameStart,nameLenght);
       //maybe remove the white spaces with String.Trim() or Regex.Replace(text,@"s","");
       //fill also the other properties
       inputList.Add(lineInput);
    }
