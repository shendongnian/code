     public partial class XtraForm_Message : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm_Message()
        {
            InitializeComponent();
        }
        public XtraForm_Message(string ClostList, string Chauffeur)
            : this()
        {
            labelControl_Trans.Text = ClostList;
            labelControl_Chauffeur.Text = Chauffeur;
        }
        private void simpleButton_oui_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }
        private void simpleButton_non_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }
