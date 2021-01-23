    private void SetColorByCellId(HtmlTable table, string id, string color)
    {
    	for (int i = 0; i < table.Rows.Count; i++)
    	{
    		for (int j = 0; j < table.Rows[i].Cells.Count; j++)
    		{
    			if (table.Rows[i].Cells[j].ID == id)
    			{
    				table.Rows[i].Cells[j].BgColor = color;
    			}
    		}
    	}
    }
