    public class SomeOtherClass
    {
        DataGridView dataGridView1;        
        
        public void PopulateDataGridView1()
        {
            dataGridView1.DataSource = new SomeClassBLL().GetAllStudents();
        }        
    }
