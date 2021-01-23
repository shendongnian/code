    public Button create_button()
    {
            btnsearchName.ID = "btnsearchName";
            btnsearchName.Text = "Search";
            btnsearchName.Click += new EventHandler(this.btnsearchName_Click);
    
           return btnsearchName;
     }
     public TextBox create_textbox()
     {
          TextBox tbsearchByName = new TextBox();
            Button btnsearchName = new Button();
            tbsearchByName.Width = 250;
            tbsearchByName.ID = "tbsearchByName";
            tbsearchByName.Text = "Enter the full name of a student";
            return tbsearchByName;
     }
    protected void btnsearchByName_Click(object sender, EventArgs e)
    {
        TextBox tbsearchByName = create_textbox();
        Button btnsearchName = create_button();
        //add to panels
        pnlsearchStudents.Controls.Add(tbsearchByName);
        pnlsearchStudents.Controls.Add(btnsearchName);
       //add to session
       List<Button> lstbutton = Session["btn"] as List<Button>
       lstbutton.add(btnsearchName);
       //similarly add textbox
      //again add to session
      Session["btn"] = lstbutton 
    }
    
    public override page_load(object sender, eventargs e)
    {
       //fetch from session, the lstButton and TextBox and recreate them
       List<Button> lstbutton = Session["btn"] as List<Button>;
       foreach(Button b in lstbutton)
           pnlsearchStudents.Controls.Add(b);
       //similar for textbox
    
    }
