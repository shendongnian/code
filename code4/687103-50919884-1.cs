    namespace DelayUpdateExample
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                this.search_textBox.TextChanged += this.Search_textBox_TextChanged;
            }
    
            private void Search_textBox_TextChanged(object sender, EventArgs e)
            {
                
            }
        }
    }
