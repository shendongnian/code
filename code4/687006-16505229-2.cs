    string text = @"RESULT: FAILED
     RESULT_CODE: 944
     RRN: 313434415392
     APPROVAL_CODE: 244447
     CARD_NUMBER: 4***********3412";
    
    using (StringReader reader = new StringReader(text))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            var values = line.Split(':');
            if (values.Length > 1)
            {
                var key = values[0].Trim();
                var val = values[1].Trim();
            }
        }
    }
