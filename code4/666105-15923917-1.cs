    namespace AddSpacesAcctoLength
      {
         public partial class Form1 : Form
         {
            public Form1()
              {
                InitializeComponent();
              }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCmd_Click(object sender, EventArgs e)
        {
            int length = 20;
            string str = txtbxText.Text;
            string strn = str.Length < length ? str.PadRight(length): str;
            MessageBox.Show(strn + "hiyya" + strn.Length.ToString());
        }
      }
    }
