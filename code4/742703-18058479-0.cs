    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Text.RegularExpressions;
    namespace testprogram
    {
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
       
        
        private void button1_Click(object sender, EventArgs e) // I'm guessing something is missing over here
        {
            int sum = Controls.Cast<Control>().Sum(c => c.Name.StartsWith("ntextBox") ? int.Parse(c.Text) : 0);
            
        }
        void HandleNTextBoxInput(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;
            if (!Regex.IsMatch(text, "^[1-9][0-9]*$")) //Text is NOT numeric. Remove [1-9] if you want to keep leading zeros.
            {
                //Set the Text to 0, for example. Or show a message box. Or whatever.
                ((TextBox)sender).Text = "0";
            }
        }
        private int _oldNUDvalue = 0; //or assign it to the default value
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            {
                int delta = (int)numericUpDown1.Value - _oldNUDvalue;
                if (delta < 0)
                {
                    for (int i = -delta; i > 0; i--)
                    {
                        var tbox = Controls.Find("ntextBox" + (_oldNUDvalue - i), false)[0];
                        Controls.Remove(tbox);
                    }
                }
                else if (delta > 0)
                {
                    for (int i = _oldNUDvalue; i < _oldNUDvalue + delta; i++)
                    {
                        var tbox = new TextBox();
                        tbox.Location = new Point(15, 55 + (30 * i));
                        tbox.Name = "ntextBox" + i;
                        tbox.TextChanged += HandleNTextBoxInput;
                        Controls.Add(tbox);
                    }
                }
                _oldNUDvalue = (int)numericUpDown1.Value;
            }
            
            
        }
    }
}
