    int  count=Gridview1.Columns.Count
    PdfPTable table = new PdfPTable(count);
    float[] columnWidths = new float[count];
    for (int v = 0; v < count; v++)
    {
        if (v == 0) { 
        columnWidths[v] = 10f;
        }
        else if (v == 2)
        {
            columnWidths[v] = 30f;
        }
        else if(v == 3)
        {
            columnWidths[v] = 15f;
        }
        else if(v == 4)
        {
            columnWidths[v] = 18f;
        }
        else if(v == 5|| v == 6|| v == 7)
        {
            columnWidths[v] = 22f;
        }
        else
        {
            columnWidths[v] = 20f;
        }
    }
       
    table.SetWidths(columnWidths);
