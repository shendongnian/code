    for(int i = 0; i < 10; i++)
    {
        lbs[i] = new Label();
        lbs[i].Location = new System.Drawing.Point(76 + f, 164);
        lbs[i].Size = new System.Drawing.Size(49, 17);
        lbs[i].Name = "label" + i;
        //able to perform this, but wont able to create a method for this
        lbs[i].Click += new System.EventHandler(lbsi_Click);
    }
    public void lbsi_Click(object sender, EventArgs e)
    {
        var label = sender as Label;
        if(label != null && label.Name == "label1"){
            //event was raised from label1
        }
    }
