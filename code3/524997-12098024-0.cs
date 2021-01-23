    public string Done_click(object sender, EventArgs e)
    {
        String a = NoteTextBox.Text;
        // on the basis of that value i have to return a string
          if    (a == "xyz") 
          {
                form1.Controls.Add( new Literal( { ID = "Literal1", Text = a } ) );
                    or 
               Response.Write(a); // It will write at the top of the page so use above code
          }
          else 
           {
                form1.Controls.Add( new Literal( { ID = "Literal1", Text = "nop" } ) );
           }
      }
