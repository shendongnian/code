	using System;
	using System.Data;
	using System.Windows.Forms;
	namespace WF_ButtonDisabling
	{
		public partial class Form1 : Form
		{
			DataTable _dt = new DataTable();
			public Form1()
			{
				InitializeComponent();
				SetupDataTable();
				CreateData();
				BindCombobox();
			}
			void SetupDataTable()
			{
				_dt.Columns.Add("Name", typeof(string));
				_dt.Columns.Add("Age", typeof(int));
			}
			void CreateData()
			{
				DataRow dr = _dt.NewRow();
				dr.SetField("Name", "Fred"); dr.SetField("Age", 45);
				_dt.Rows.Add(dr);
				dr = _dt.NewRow();
				dr.SetField("Name", "John"); dr.SetField("Age", 42);
				_dt.Rows.Add(dr);
				dr = _dt.NewRow();
				dr.SetField("Name", "Tom"); dr.SetField("Age", 49);
				_dt.Rows.Add(dr);
			}
			void BindCombobox()
			{
				comboBox1.DisplayMember = "Name";
				comboBox1.ValueMember = "Age";
				comboBox1.DataSource = _dt;
				comboBox1.SelectedIndex = 0;
			}
			void button1_Click(object sender, EventArgs e)
			{
				DeleteRow(comboBox1.SelectedIndex);
			}
			void DeleteRow(int index)
			{
				_dt.Rows[index].Delete();
				BindCombobox();
				button1.Enabled = false;
			}
		}
	}
