    void insert( List<string> value)
    {
        //for the first 26 data
        range = objSheet.get_Range("C17:C42", Missing.Value);
        object[,] numbers1 = new object[26, 1];
        for (int i = 0; i <= 25; i++)
        {
            //value contains the data
            numbers1[i, 0] = value[i];
        }
         range.Value2 = numbers1;
    }
    
    //Get value from richtextbox
    string s = richTextBoxReceive.Text;
    var k = Regex.Split(s, "\\n", RegexOptions.Multiline);
    List<string> allvalue=new List<string>();
    foreach (string str in k)
    {
        allvalue.Add(str);
    }
    //call insert method to insert data into excell
    insert(allvalue);
