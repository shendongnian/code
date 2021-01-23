    int c = 2;//column b
    while(true)
    {
        if (String.IsNullOrEmpty(worksheet.GetRange(1,c).Value2))
        {
            c--;
            break;
        }
        c++;
    }
    
