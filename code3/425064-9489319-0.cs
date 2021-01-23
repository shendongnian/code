    public partial class Form1 : Form
    {
           public Form1()
           {
               InitializeComponent();
           }
    
           private void button1_Click(object sender, EventArgs e)
           {
               DataTable myTable = new DataTable("MyTable");
               myTable.Columns.Add("CategoryID", typeof(int));
               myTable.Columns.Add("CategoryName", typeof(string));
               myTable.Rows.Add(new object[] { 1, "Small" });
               myTable.Rows.Add(new object[] { 2, "Medium" });
               myTable.Rows.Add(new object[] { 3, "Large" });
    
               DataGridViewComboBoxColumn cboCategory = new DataGridViewComboBoxColumn();
               cboCategory.HeaderText = "Category";
               cboCategory.DataSource = myTable;
               cboCategory.DisplayMember = "CategoryName";
               cboCategory.ValueMember = "CategoryID";
               cboCategory.DataPropertyName = "Category";
               cboCategory.Width = Convert.ToInt16(dataGridView1.Width * 0.20);
               cboCategory.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
               cboCategory.AutoComplete = true;
    
               dataGridView1.Columns.Add(cboCategory);
    
           }
    }
