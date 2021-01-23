    foreach (thing in your ArrayList)
    {
         TabPage tabPage = new TabPage("Name of tab");      // Add a new tab page
         RichTextBox rtb = new System.Windows.Forms.RichTextBox();//RTF box
         TextBox tb = new System.Windows.Forms.TextBox(); //Text box
         
              //Set up size and position and properties of your RTB here
         rtb.LoadFile("some/Path/to/a/file");
         
                    //set up size, position of properties of TextBox here
         tb.Text = "Some text I want to display";
         tabPage.Controls.Add(rtb); //Add both boxes to that tab
         tabPage.Controls.Add(tb);
         tabControl1.TabPages.Add(tabPage); //Add that page to the tab control
         tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
    }
