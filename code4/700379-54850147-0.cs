    PictureBox[] picboxes = new PictureBox[result];
    for (int i = 0; i < results; i++)
    {
        picboxes[i] = new PictureBox();
        picboxes[i].Tag = (i+1).ToString();
        picboxes[i].ImageLocation = @FormIni.RetRes((i * 5) + 5 + i);
        picboxes[i].Click += new System.EventHandler(PictureBoxes_Click);
    }
    
    private void PictureBoxes_Click(object sender, EventArgs e)
    {
        PictureBox p = (PictureBox)sender;
        string j = p.tag.tostring();
        label1.Text = j;
    } 
