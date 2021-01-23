    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string DataFormatName = "SomeCustomDataFormatName";
        private void DragDrop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Label source = (Label)sender;
                DataObject data = new DataObject(DataFormatName, source);
                source.DoDragDrop(data, DragDropEffects.Copy);
            }
        }
        private void DragDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormatName))
                e.Effect = e.AllowedEffect;
            else
                e.Effect = DragDropEffects.None;
        }
        private void DragDrop_DragDrop(object sender, DragEventArgs e)
        {
            Label target = (Label)sender;
            Label source = (Label)e.Data.GetData(DataFormatName);
            string tmp = target.Text;
            target.Text = source.Text;
            source.Text = tmp;
        }
    }
