    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // other special GUIDs are defined in Windows SDK's ShlGuid.h
            Guid CLSID_MyComputer = new Guid("20D04FE0-3AEA-1069-A2D8-08002B30309D");
            FolderBrowser dlg = new FolderBrowser();
            dlg.Title = "Choose any folder you want";
            // optionally uncomment the following line to start from a folder
            //dlg.SelectedPath = @"c:\temp";
            // optionally uncomment the following line to start from My Computer/This PC
            //dlg.SelectedDesktopAbsoluteParsing = "::" + CLSID_MyComputer.ToString("B");
            if (dlg.ShowDialog(null) == DialogResult.OK)
            {
                MessageBox.Show(dlg.SelectedDesktopAbsoluteParsing + Environment.NewLine +
                    dlg.SelectedNormalDisplay + Environment.NewLine +
                    dlg.SelectedPath + Environment.NewLine +
                    dlg.SelectedUrl);
                if (dlg.SelectedDesktopAbsoluteParsing == "::" + CLSID_MyComputer.ToString("B").ToUpperInvariant())
                {
                    MessageBox.Show("My Computer was selected!");
                }
            }
        }
    }
    
