    for (int count = 0; count < ds.Tables[0].Rows.Count; count++)
    {
    
        if (txtwbs.Text == ds.Tables[0].Rows[count][0].ToString())
        {
              Lbmsg.Visible = true;
              Lbmsg.Text = "Data Already Exists !";
              doesExist = true;
              break;
        }
    }
    if(!doesExist)
        insetreco(val);
