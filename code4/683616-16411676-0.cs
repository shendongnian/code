        TextBox MyTextBox=new TextBox();
    //Assigning the textbox ID name 
    MyTextBox.ID = "name" +""+ ViewState["val"] + i;
    MyTextBox.Width = 440;
    MyTextBox.Height = 40;
    MyTextBox.TextMode = TextBoxMode.MultiLine;
    this.Controls.Add(MyTextBox);
