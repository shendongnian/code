    public class
    {
    static string listme;
     
    public Form1()
            {
                InitializeComponent();
                this.Shown += new EventHandler(listBox1_SelectedIndexChanged);
    
            }
    public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                listBox1.SelectedIndex = 0;
                listme = listBox1.GetItemText(listBox1.SelectedItem);
    
                MessageBox.Show(Backups + @"\" + listme);
    
    
            }
