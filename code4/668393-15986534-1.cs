        foreach (DataRow dr in blCategorie.getAlleCategorieenMetLimieten())
        {
            //making labels dyanmic and fill them with the correct text (from database)
            string categorie = (string)dr.Field<string>("Omschrijving");
            Label label = new Label();
            label.BackColor = Color.Transparent;
            label.ForeColor = Color.FromArgb(97, 97, 97);
            label.Font = new Font("Myriam Pro", 10, FontStyle.Bold);
            label.Width = 200;
            label.Name = categorie;
            label.Text = categorie;
            label.BackColor = Color.Transparent;
            label.Location = new Point(10, beginningHeight + addingToHeight);
            maxleftpos = Math.Max(label.Left + label.Width, maxleftpos);
            this.Controls.Add(label);
            // getting the figures (max figures) from the db to show in a label
            double limiet = (double)dr.Field<double>("maximumBedrag");
            maxLimit = Math.Max(limiet, maxLimit);
            Label labeltest = new Label();
            labeltest.BackColor = Color.Transparent;
            labeltest.ForeColor = Color.FromArgb(97, 97, 97);
            labeltest.Font = new Font("Myriam Pro", 8, FontStyle.Bold);
            labeltest.Width = 200;
            labeltest.Name = Convert.ToString(limiet);
            labeltest.Text = "Limiet: " + Convert.ToString(limiet) + "€";
            labeltest.BackColor = Color.Transparent;
            labeltest.Location = new Point(30, (beginningHeight + 27) + addingToHeight);
            this.Controls.Add(labeltest);
            //making pictureboxes for every single row in the db
            PictureBox picturebox = new PictureBox();
            picturebox.Width = 200;
            picturebox.Name = "picturebox" + i;
            picturebox.Height = 15;
            picturebox.Tag = limiet;
            picturebox.Location = new Point(100, (beginningHeight + 27) + addingToHeight);
            this.Controls.Add(picturebox);
            picturebox.BringToFront();
            //calling the paint event for drawing inside the pictureboxes
            picturebox.Paint += new PaintEventHandler(picturebox_Paint);
            //adjusting height (55px extra per new row)
            beginningHeight += 55;
            i++;
        }
        foreach (Control c in this.Controls)
        {
            if (c is PictureBox)
            {
                c.Location = new Point(maxleftpos, c.Top);
            }
        }
        if (this.Width<maxleftpos+150)
        {
            this.Width = maxleftpos + 50;
        }
        this.Refresh();
    }
    private void picturebox_Paint(object sender, PaintEventArgs e)
    {
        PictureBox p = sender as PictureBox;
        Graphics gr = e.Graphics;
        gr.ResetTransform();
        //Graphics g = picturebox.CreateGraphics();
        int breedteGebruikt = Convert.ToInt32((double)p.Tag);
        int max = Convert.ToInt32(maxLimit);
        int grwidht = breedteGebruikt * p.Width / max;
        gr.DrawRectangle(new Pen(Color.Red), new Rectangle(10, 5, 50, 5));
        gr.FillRectangle(Brushes.Green, 0, 0, p.Width, p.Height);
        gr.FillRectangle(Brushes.Red, 0, 0, grwidht, p.Height);
    }
