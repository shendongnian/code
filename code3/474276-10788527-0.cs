    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            Application.Idle += Application_Idle;
            this.FormClosed += delegate { Application.Idle -= Application_Idle; };
        }
        void Application_Idle(object sender, EventArgs e) {
            bool focusOk = this.ActiveControl == SelectedLV;
            bool selectOk = SelectedLV.SelectedIndices.Count == 1;
            int index = selectOk ? SelectedLV.SelectedIndices[0] : -1;
            MoveUpBtn.Enabled = focusOk && selectOk && index > 0;
            MoveDownBtn.Enabled = focusOk && selectOk && index < SelectedLV.Items.Count-1;
        }
    }
