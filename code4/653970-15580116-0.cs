    string str_Checkboxes="";
    string str_SQL = "SELECT Name, File, Action, Fantasy, Horror, Thriller, Adventure, Animation, Comedy, Crime, Documentary, Drama, Family, Games, Mystery, Romance, SciFi, War FROM tbl_Main WHERE ";
    
    //Loop through each control on the form, we are looking for checkboxes
    foreach (Control c in this.Controls)
     {
      if(c is CheckBox)
        {
          if (((CheckBox)c).Checked)
            {
             //Bypass putting AND at the beginning of str_Checkboxes
             if(str_Checkboxes != "")
               str_Checkboxes+=" AND ";
             //Checkbox text is the same as the field name in the database
               str_Checkboxes += (((CheckBox)c).Text) + " = True";
            }
         }
       }
    //build the SQL
    str_SQL += str_Checkboxes + ";"; 
    //Fill the grid
    Fill_Grid(str_SQL);
