    int count = YourControl.Rows.Count;
    for (int i = 0; i <= count; i++)
    {
        if (condition)
        { 
           YourControl.DeleteRow(i);
        }
    }
