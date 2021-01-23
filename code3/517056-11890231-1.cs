    public partial class frmMain : Form
    {
        // Intial Declerations and initializations
        Boolean bReady = false;       // Secondary trigger for DataGridView selection
        string clrTest = "Test";      // Default display text - Clear filter text; Used to ignore the setting if this text is visible
        string currentText;           // Comboboxes' currently displayed text
        
        // Form execution
        public frmMain()
        {
            InitializeComponent();
        }
        // Some code...
        //
        // ComboBoxes on KeyPress event
        //      - Used as a workaround for MS ComboBoxes not updating their text correctly
        //      - Shared across all ComboBoxes (as applied by the individual controls' event handlers)
        //
        private void ComboBoxKeyUp(object sender, KeyEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            currentText = cmb.Text;
        }
        // Any trigger you want that requires the ComboBoxes text
        private void cmbxTest_DropDownClosed(object sender, EventArgs e)
        {
            if (!cmbxTest.Text.Equals(clrTest))
            {
                cmbxTest.Text = currentText;
            }
            // Do any other code that requires the cmbxTest.Text
            Console.WriteLine(cmbxTest.Text);
        }
    }
