     protected void Repeater_OnItemCommand(object source, RepeaterCommandEventArgs e)
            {
                if (e.CommandName.Equals("AddNote"))
                {       
                string FID =e.CommandArgument.ToString();    
                TextBox txtNote=e.Item.FindControl("NoteTextBox") as TextBox;    
                string note=txtNote.Text; 
                Response.Write(FID + " " + note);
                }
        }
