    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
           ((Control)sender).DoDragDrop(((Control)sender).BackColor,DragDropEffects.All);
        }
        private void panel_DragDrop(object sender, DragEventArgs e)
        {
            ((Control)sender).BackColor = (Color)e.Data.GetData(BackColor.GetType());
        }
        private void panel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
