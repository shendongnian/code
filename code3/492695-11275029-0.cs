    List<PictureBox> pictureBoxList = new List<PictureBox>();
    
    for (int i = 0; i < dt.Rows.Count; i++)
    {
    	PictureBox picture = new PictureBox
    	{
    		Name = "pictureBox" + i,
    		Size = new Size(316, 320),
    		Location = new Point(i * 316, 1),
    		BorderStyle = BorderStyle.FixedSingle,
    		SizeMode = PictureBoxSizeMode.Zoom
    	};
    	picture.ImageLocation = dt.Rows[i]["FileName"].ToString();
    	pictureBoxList.Add(picture);
    }
    
    foreach (PictureBox p in pictureBoxList)
    {
    	pnlDisplayImage.Controls.Add(p);
    }
