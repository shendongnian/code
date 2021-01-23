    // say this is your User class with 9 fields
	public class User
	{
		public string Name { get; set; }
		public string LastName { get; set; }
		public string FatherName { get; set; }
		public string Telephone { get; set; }
		public string Mobile { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public bool IsActive { get; set; }
		public DateTime LastLoginDate { get; set; }
	}
    // and your Form1 class would be like this
    public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			dataGridView1.AutoGenerateColumns = false;
			// say you want to show, only the first 5 fields of your Entity
			dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "Name", Width=100 });
			dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Last Name", DataPropertyName = "LastName", Width = 100 });
			dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Father's Name", DataPropertyName = "FatherName" });
			dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Telephone", DataPropertyName = "Tel", Width = 50 });
			dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mobile", DataPropertyName = "Mobile", Width = 50 });
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			List<User> list = new List<User>();
			list.Add(new User { Name="aaa", LastName="bbbb", FatherName="ccc", Tel="01111", Mobile="099999" });
			dataGridView1.DataSource = list.ToArray();
		}
	}						 
