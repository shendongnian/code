    foreach (Control MyCtrl in this.Controls)
    {
    	DoAllRichTextBoxes(MyCtrl);
    }
    void DoAllRichTextBoxes(Control control)
    {
    	ComboBox Cmb = control as ComboBox;
    	TextBox TxtBx = control as TextBox;
    	if (Cmb == null && TxtBx == null)
    	{
    		// deal with nested controls
    		foreach (Control c in control.Controls) DoAllRichTextBoxes(c);
    	}
    	if (Cmb != null)
    	{
    		Cmb.GotFocus += new EventHandler(this.Tb_GotFocus);
    		Cmb.LostFocus += new EventHandler(this.Tb_LostFocus);
    		Cmb.KeyDown += new KeyEventHandler(this.VehComn_KeyDown);
    		Cmb.SelectedValueChanged += new EventHandler(this.AllCombos_SelectedValueChanged);
    	}
    	if (TxtBx != null)
    	{
    		TxtBx.GotFocus += new EventHandler(this.Tb_GotFocus);
    		TxtBx.LostFocus += new EventHandler(this.Tb_LostFocus);
    		TxtBx.KeyPress += new KeyPressEventHandler(this.TbCmb_KeyPress);
    		TxtBx.KeyDown += new KeyEventHandler(this.VehComn_KeyDown);
    	}
    }
