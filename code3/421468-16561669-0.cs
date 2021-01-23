    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
    	// Note this assumes there is only one ComboBox column in the grid!
    	var comboBox = e.Control as ComboBox;
    	if (comboBox == null)
    		return;
    
    	comboBox.DrawMode = DrawMode.OwnerDrawFixed;
    	comboBox.DrawItem -= DrawGridComboBoxItem;
    	comboBox.DrawItem += DrawGridComboBoxItem;
    }
    
    private void DrawGridComboBoxItem(object sender, DrawItemEventArgs e)
    {
    	e.DrawBackground();
    
    	if (e.Index != -1)
    	{
    		// Determine which foreground color to use
    		var itemValue = actionsColumn.Items[e.Index] as string;
    		bool isNo = String.Equals("no", itemValue, StringComparison.CurrentCultureIgnoreCase);
    		Color color = isNo ? Color.Red : e.ForeColor;
    
    		using (var brush = new SolidBrush(color))
    			e.Graphics.DrawString(itemValue, e.Font, brush, e.Bounds);
    	}
    
    	e.DrawFocusRectangle();
    }
