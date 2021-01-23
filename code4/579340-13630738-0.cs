    protected void Page_Load(object sender, EventArgs e)
    {
        for(int i = 0; i < tableAppointment.Rows.Count; i++)
        {
            for(int j = 0; j < tableAppointment.Rows[i].Cells.Count; j++)
            {
                 // Assuming you have set the rowSpan by now.
                 // TODO: Handle the possibility of missing rowspan attribute.
                 int rowSpan = int.Parse(tableAppointment.Rows[i].Cells[j].Attributes["rowspan"]);
                 if (rowSpan > 0) {
                    // Now try to look ahead for rows and remove their j'th cell.
                    for (int k = j+1; k < j + rowSpan; k++)
                    {
                       tableAppointment.Rows[k].Cells.RemoveAt(j);
                       // TODO: Validate if k is not beyond available rows. It shoudn't be if rowspans are correct.
                    }
                 }
            }        //Here i have to remove those extra cell added after giving rowspan       
        }
    }
