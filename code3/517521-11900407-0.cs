    public void create_button()
    {
            TextBox tbsearchByName = new TextBox();
            Button btnsearchName = new Button();
            tbsearchByName.Width = 250;
            tbsearchByName.ID = "tbsearchByName";
            tbsearchByName.Text = "Enter the full name of a student";
            btnsearchName.ID = "btnsearchName";
            btnsearchName.Text = "Search";
            btnsearchName.Click += new EventHandler(this.btnsearchName_Click);
    
            pnlsearchStudents.Controls.Add(tbsearchByName);
            pnlsearchStudents.Controls.Add(btnsearchName);
            
    //add these to session
            lstButton.add(btnsearchName);
            lstTextbox.add(tbsearchByName);
     }
    
    public override page_load(object sender, eventargs e)
    {
       //fetch from session, the lstButton and TextBox and recreate them
    
    }
