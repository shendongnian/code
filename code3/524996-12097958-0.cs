    public string Done_click(object sender, EventArgs e) {
            String a = NoteTextBox.Text;
            // on the basis of that value i have to return a string
              if(a == "xyz") {Response.Write(a);}
              else {Response.Write("nop");}
          }
