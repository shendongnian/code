    static int myCount = 0;
        private TextBox[] dynamicTextBoxes;
    
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Control myControl = GetPostBackControl(this.Page);
    
            if ((myControl != null))
            {
                if ((myControl.ClientID.ToString() == "btnAddTextBox"))
                {
                    myCount = myCount + 1;
                }
            }
        }
    
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            dynamicTextBoxes = new TextBox[myCount];
            int i;
            for (i = 0; i < myCount; i += 1)
            {
                TextBox textBox = new TextBox();
                textBox.ID = "myTextBox" + i.ToString();
                myPlaceHolder.Controls.Add(textBox);
                dynamicTextBoxes[i] = textBox;
                LiteralControl literalBreak = new LiteralControl("<br />");
                myPlaceHolder.Controls.Add(literalBreak);
            }
        }
    
        protected void btnAddTextBox_Click(object sender, EventArgs e)
        {
            // Handled in preInit due to event sequencing.
        }
    
        protected void MyButton_Click(object sender, EventArgs e)
        {
            MyLabel.Text = "";
            foreach (TextBox tb in dynamicTextBoxes)
            {
                MyLabel.Text += tb.Text + " :: ";
            }
        }
    
        public static Control GetPostBackControl(Page thePage)
        {
            Control myControl = null;
            string ctrlName = thePage.Request.Params.Get("__EVENTTARGET");
            if (((ctrlName != null) & (ctrlName != string.Empty)))
            {
                myControl = thePage.FindControl(ctrlName);
            }
            else
            {
                foreach (string Item in thePage.Request.Form)
                {
                    Control c = thePage.FindControl(Item);
                    if (((c) is System.Web.UI.WebControls.Button))
                    {
                        myControl = c;
                    }
                }
            }
            return myControl;
        }
