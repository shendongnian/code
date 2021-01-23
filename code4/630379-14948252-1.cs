    public partial class Form1 : Form
    {
        List<TruthTableEntry> table;
    
        public Form1()
        {
            // generate a 3-input truth table (8 input variations)
            table = GenerateTruthTable(3);
            // setup DataGridView
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].DataPropertyName = "A";
            dataGridView1.Columns[1].DataPropertyName = "B";
            dataGridView1.Columns[2].DataPropertyName = "C";
            dataGridView1.Columns[3].DataPropertyName = "D";
            dataGridView1.Columns[4].DataPropertyName = "Out";
            // hide column 3 ('D') as unused
            dataGridView1.Columns[3].Visible = false;
        }
    }
