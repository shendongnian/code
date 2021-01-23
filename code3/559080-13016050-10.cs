    public partial class TestForm : Form, ITestView
    {
        public event EventHandler Load;    
        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            if (Load != null)
                Load(this, EventArgs.Empty);
        }
    
        public void LoadList(IEnumerable<AppSignatureDto> data)
        {
            // populate grid view here
        }
    } 
