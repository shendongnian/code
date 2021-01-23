    namespace System.Windows.Forms
    {
        public class UnChangingCheckBox : System.Windows.Forms.CheckBox
        {
            public UnChangingCheckBox()
            {
                this.Click += new EventHandler(UnChangingCheckBox_Click);
            }
    
            void UnChangingCheckBox_Click(object sender, EventArgs e)
            {
                ((CheckBox)sender).Checked = !((CheckBox)sender).Checked;
            }
        }
    }
