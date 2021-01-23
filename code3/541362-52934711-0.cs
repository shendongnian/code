        string[] autosource= File.ReadAllLines(@"autocomplete.txt");
        for(int g = 0; g < autosource.Length; g++)
        {
            textboxname.AutoCompleteCustomSource.Add(autosource[g]);
        }
       textboxname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
