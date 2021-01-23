    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace MSLabExample
    {
        class RadioButtonBind : RadioButton
        {
            private string _selectValue = string.Empty;
            public string SelectValue
            {
                get { return _selectValue; }
                set
                {
                    if (value == Text) Checked = true;
                    else Checked = false;
                    _selectValue = value;
                }
            }
    
            public RadioButtonBind()
            {
                this.CheckedChanged += new EventHandler(RadioButtonBind_CheckedChanged);
                this.TextChanged += new EventHandler(RadioButtonBind_TextChanged);
            }
            void RadioButtonBind_TextChanged(object sender, EventArgs e)
            {
                if (Checked) _selectValue = Text;
            }
            void RadioButtonBind_CheckedChanged(object sender, EventArgs e)
            {
                if (Checked) _selectValue = Text;
            }
        }
    }
