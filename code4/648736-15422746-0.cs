    public partial class MyForm : Form {
        
        private TextBox _textbox1; // this field exists in the MyForm.designer.cs file
        
        // this property should be in your MyForm.cs file
        public String TextBox1Value {
            get { return _textbox1.Text; }
            set { _textbox1.Text = value; }
        }
    }
