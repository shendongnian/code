    public partial class Form1 : Form
    {
        public bool EditedFlag=false;
       
        private void Changed(object sender, EventArgs e)
        {
            EditedFlag=true;
        }
        public Form1()
        {
            InitializeComponent();            
            foreach (Control ctrl in this.Controls)
            {
                ControlEvents(ctrl);
            }
        } 
        public void ControlEvents<T>(T sender)
        {            
            if (sender is TextBox) 
            {
                var obj = sender as TextBox;
                obj.TextChanged+= new EventHandler(Changed);
            }
            if (sender is CheckBox)
            {
                var obj = sender as CheckBox;
                obj.CheckedChanged += new EventHandler(Changed);
            }
            if (sender is ComboBox)
            {
                var obj = sender as ComboBox;
                obj.SelectedIndexChanged += new EventHandler(Changed);
            }
 
        }}
