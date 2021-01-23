    ColA|ColB|3*|Note1|Note2|Note3|2**|A1|A2|A3|B1|B2|B3
    string[] columns = line.Split('|');
    List<string> repeatingColumnNames = new List<string();
    List<List<string>> repeatingFieldValues = new List<List<string>>();
    if(columns.Length > 2)
    {
        int repeatingFieldCountIndex = columns[2];
        int repeatingFieldStartIndex = repeatingFieldCountIndex + 1;
        for(int i = 0; i < repeatingFieldCountIndex; i++)
        {
            repeatingColumnNames.Add(columns[repeatingFieldStartIndex + i]);
        }
        int repeatingFieldSetCountIndex = columns[2 + repeatingFieldCount + 1];
        int repeatingFieldSetStartIndex =  repeatingFieldSetCountIndex + 1;
        for(int i = 0;  i < repeatingFieldSetCount; i++)
        {
            string[] fieldSet = new string[repeatingFieldCount]();
            for(int j = 0; j < repeatingFieldCountIndex; j++)
            {                             
                fieldSet[j] = columns[repeatingFieldSetStartIndex + j  + (i  * repeatingFieldSetCount))];
            }
            repeatingFieldValues.Add(new List<string>(fieldSet));
         }
    }
