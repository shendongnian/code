    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int lastIndex = -1;
        bool suppressSelectedIndexChanged;
        //Click event handler for buttonAdd
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            suppressSelectedIndexChanged = true;
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            suppressSelectedIndexChanged = false;
        }
        //Click event handler for buttonRemove
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count == 0) return;
            int k = listBox1.SelectedIndices[0];
            suppressSelectedIndexChanged = true;
            for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
                listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
            suppressSelectedIndexChanged = false;
            lastIndex = -1;
            listBox1.SelectedIndex = k < listBox1.Items.Count ? k : listBox1.Items.Count - 1;
            if (listBox1.Items.Count == 0) textBox1.Clear();
        }
        //Click event handler for buttonSave
        private void buttonSave_Click(object sender, EventArgs e)
        {            
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "URLs file|*.urls";
            save.FileOk += (s, ev) =>
            {
                using (StreamWriter writer = File.CreateText(save.FileName))
                {
                    foreach (object item in listBox1.Items)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
            };
            save.ShowDialog();
        }
        //Click event handler for buttonOpen
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "URLs file|*.urls";
            open.FileOk += (s, ev) =>
            {
                listBox1.Items.Clear();
                using (StreamReader reader = File.OpenText(open.FileName))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        listBox1.Items.Add(line);
                    }
                }
            };
            open.ShowDialog();
        }
        //SelectedIndexChanged event handler for listBox1
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressSelectedIndexChanged) return;
            if (lastIndex > -1)
            {
                listBox1.Items[lastIndex] = textBox1.Text;                
            }            
            lastIndex = listBox1.SelectedIndex;
            if (listBox1.SelectedIndex > -1)
                textBox1.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
        }
        //Click event handler for buttonVisit
        private void buttonVisit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            System.Diagnostics.Process.Start(listBox1.SelectedItem.ToString());
        }
    }
