    public partial class Editor : Form
    {
        public string YourReturnValue { get; private set; }
        private void btnClose_Click(object sender, EventArgs e)
        {
            // you code here...
            YourReturnValue = "Something you want to return";
        }
     }
