    using System;
    using System.Windows.Forms;
    namespace KeyDemoForm
    {
    public partial class KeyDemoForm : Form
    {
       
       public KeyDemoForm()
        {
            InitializeComponent();
        }
        public void KeyDemoForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            charLabel.Text = "Key pressed: " + e.KeyChar;
        }
        public void KeyDemoForm_KeyDown(object sender, KeyEventArgs e)
        {
            KeyInfoLabel.Text =
             "Alt:  " + (e.Alt ? "yes" : "No") + '\n' +
             "Shift:  " + (e.Shift ? "yes" : "No") + '\n' +
             "Ctrl:  " + (e.Control ? "yes" : "No") + '\n' +
             "KeyCode:  " + e.KeyCode + '\n' +
             "KeyValue:  " + e.KeyValue + '\n' +
             "KeyData:  " + e.KeyData;
        }
        public void KeyDemoForm_KeyUp(object sender, KeyEventArgs e)
        {
            charLabel.Text = " ";
            KeyInfoLabel.Text = " ";
        }
        public void KeyDemoForm_Load(object sender, EventArgs e)
        {            
            this.KeyPreview = true;
            this.KeyDown   += KeyDemoForm_KeyDown;
            this.KeyUp     += KeyDemoForm_KeyUp;
            this.KeyPress  += KeyDemoForm_KeyPress;
        } 
    }
    }
