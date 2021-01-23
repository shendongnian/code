    string[] colString = new string{ "Email ID", "Phone", "Address" };
    int colIndex = 0;
    foreach (ColumnHeader lstViewCol in lvFiles.Columns)
    {
      lstViewCol.Text = colString[colIndex];
      colIndex++;
    }
