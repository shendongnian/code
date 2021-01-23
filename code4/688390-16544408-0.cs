    public void btnConvertToBraille_Click(object sender, EventArgs e)
    {
        GUI.TamilToBrailleGUI c1 = new GUI.TamilToBrailleGUI(richTextBoxTamil.Text);
        c1.Visible = true;            
    }
