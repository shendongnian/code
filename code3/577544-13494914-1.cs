    public partial class Form2 : Form
    {
        public Form2(CheckedListBox checkedListBox1)
        {
            InitializeComponent();
            foreach(string item in checkedListBox1.CheckedItems)
            {
                listBox1.Items.Add(item);
            }
        }
    }
