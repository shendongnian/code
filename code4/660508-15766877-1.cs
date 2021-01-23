    namespace System.Windows.Forms
    {
        public class UnChangingCheckbox : System.Windows.Forms.CheckBox
        {
            public UnChangingCheckbox()
            {
                this.Click += new EventHandler(UnChangingCheckbox_Click);
            }
    
            void UnChangingCheckbox_Click(object sender, EventArgs e)
            {
                ((CheckBox)sender).Checked = !((CheckBox)sender).Checked;
            }
        }
    }
