    // Don't forget to change DrawMode, else the DrawItem event won't be called.
    // this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
    
    private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
    	ComboBox comboBox = (ComboBox)sender;
    
    	if (IsItemDisabled(e.Index))
    	{
    		// NOTE we must draw the background or else each time we hover over the text it will be redrawn and its color will get darker and darker.
    		e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
    		e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), comboBox.Font, SystemBrushes.GrayText, e.Bounds);
    	}
    	else
    	{
    		e.DrawBackground();
    		e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), comboBox.Font, SystemBrushes.ControlText, e.Bounds);
    		e.DrawFocusRectangle();
    	}
    }
    
    void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    	if (IsItemDisabled(comboBox1.SelectedIndex))
    		comboBox1.SelectedIndex = -1;
    }
    
    bool IsItemDisabled(int index)
    {
    	// We are disabling item based on Index, you can have your logic here
    	return index % 2 == 1;
    }
