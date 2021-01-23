    public partial class Employee_PayHeads_add : Form
    {
        private TextBox txtBox = new TextBox();
        private Button btnAdd = new Button();
        private ComboBox combohead = new ComboBox();
        private int txtBoxStartPosition = 150;
        private int btnAddStartPosition = 240;
        private int comboheadStartPosition = 10;
    }
    public Employee_PayHeads_add()
    {
        InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        TextBox newTxtBox = new TextBox();
        Button newBtnAdd = new Button();
        ComboBox newCombohead = new ComboBox();
        newBtnAdd.BackColor = Color.Gray;
        newBtnAdd.Text = "Remove";
        newBtnAdd.Location = new System.Drawing.Point(btnAddStartPosition, 25);
        newBtnAdd.Size = new System.Drawing.Size(70, 25);
        newTxtBox.Text = "";
        newTxtBox.Location = new System.Drawing.Point(txtBoxStartPosition, 25);
        newTxtBox.Size = new System.Drawing.Size(70, 40);
        newCombohead.Location = new System.Drawing.Point(comboheadStartPosition, 25);
        panel1.Controls.Add(newBtnAdd);
        panel1.Controls.Add(newTxtBox);
        panel1.Controls.Add(newCombohead);
        txtBoxStartPosition += 50;
        btnAddStartPosition += 50;
        comboheadStartPosition += 50;
    }
