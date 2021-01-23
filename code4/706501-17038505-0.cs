    using Microsoft.VisualBasic;
    
    
      // Click-Event
      private void btn_GetName_Click(object sender, EventArgs e)
      {
            string btnTxt = Interaction.InputBox("Title", "Message", "defaultValue", 10, 10);
            Button button1 = new Button();
            button1.Location = new Point(20, 10);
            button1.Text = btnTxt;
            this.Controls.Add(button1);
      }
