    public class DataBindingObj
    {
        public DateTime DateRemoved { get; set; }
    }
    dataGridView1.AutoGenerateColumns = true;
    dataGridView1.DataSource = bindingObjs;
    dataGridView1.Columns["DateRemoved"].Format = "d";
    
