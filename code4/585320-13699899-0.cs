    Label lblMotive = new Label();
    lblMotive.Text = language.motive;
    lblMotive.Location = new Point(0, 40);
    
    Label lblDiagnosis = new Label();
    lblDiagnosis.Text = language.diagnosis;
    lblDiagnosis.Location = new Point(0, lblMotive.Location.Y + lblMotive.Size.Height + 10);
    
    panelServiceMotive.Controls.Add(lblMotive);
    panelServiceMotive.Controls.Add(lblDiagnosis);
