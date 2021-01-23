    List<string> list = new List<string>();
    foreach(Control c in this.Controls)
    {
      if(c is TextBox)
         list.Add((c as Textbox).Text);
    }
