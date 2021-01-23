    private void Form1_Load(object sender, EventArgs e)
        {
     foreach (Control x in this.Controls)
                {
                    if(x is Label)
                        ((Label)x).MouseHover+=new EventHandler(AllLabels_HoverEvent);
                        else if(x is TextBox)
                        ((TextBox)x).MouseHover+=new EventHandler(AllTextboxes_HoverEvent);
                }
    }
    void AllLabels_HoverEvent(object sender, EventArgs e)
            {
                  Label label = sender as Label;
               // label.dowhateveryouwant...
            }
            void AllTextboxes_HoverEvent(object sender, EventArgs e)
            {
                Textbox textbox = sender as Textbox;
               // textbox.dowhateveryouwant...
            }
