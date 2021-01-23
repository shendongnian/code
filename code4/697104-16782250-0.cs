    int cptx = 0;
    int cpty = 0;
    for(int i=0; i<ds.Tables[0].Rows.Count;i++)
    {
        PictureBox currentpic = new PictureBox();
        Label currentlabel = new Label();
        currentpic.Size = new Size(20,20);
        currentlabel.Size = new Size(20,20);
        currentpic.BorderStyle = BorderStyle.FixedSingle;
        currentlabel.Text = "te";
        if(cptx >= 4)
        {
            cptx = 0;
            cpty ++;
        }
        currentpic.Location= new Point((cptx*25),(cpty*50));
        currentlabel.Location = new Point((cptx*25),(cpty*50)+25);
        This.Controls.Add(currentpic);
        
        cptx ++;
    }
