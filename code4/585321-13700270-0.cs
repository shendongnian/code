    private void button1_Click(object sender, EventArgs e)
    {
      Panel panelServiceMotive = new Panel();
      Label lblMotive = new Label();
      lblMotive.Text = "motive";
      lblMotive.Location = new Point(0, 0);
      Label lblDiagnosis = new Label();
      lblDiagnosis.Text = "language";
      lblDiagnosis.Location = new Point(100, 0);
      panelServiceMotive.Controls.Add(lblMotive);
      panelServiceMotive.Controls.Add(lblDiagnosis);
      this.Controls.Add(panelServiceMotive);
    }
