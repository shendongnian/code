    string[] longMsg = str.Split('*'); //Message contains * character as delimiter
    
    
    for (int i = 0; i < longMsg.Length; i++)
    {
      CheckBox cb = new CheckBox();
      cb.Text = longMsg[i];
      
      Literal br = new Literal();
      br.Text = "<br/>";
      
      Form.Controls.Add(cb);
      Form.Controls.Add(br );
    }
