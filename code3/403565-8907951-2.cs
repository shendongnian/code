        HtmlGenericControl myDiv = new HtmlGenericControl("div");
        myDiv.ID = "myDiv";
        LinkButton myLnkBtn = new LinkButton();
        myLnkBtn.ID = "myLnkBtn";
        myLnkBtn.Click += new EventHandler(myLnkBtn_Click);
        myLnkBtn.Text = "I'm dynamic";
        myDiv.Controls.Add(myLnkBtn);
        PlaceHolder1.Controls.Add(myDiv);
