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
    // Create a truth table for 1-4 inputs
    static List<TruthTableEntry> GenerateTruthTable(int numInputs)
    {
        // range-check number of inputs
        if (numInputs < 1 || numInputs > 4)
            return null;
        // calculate number of input states
        int permutations = 1 << numInputs;
        // create result list of input states
        List<TruthTableEntry> res = new List<TruthTableEntry>();
        for (int i = 0; i < permutations; ++i)
        {
            // use bit manipulation to initialize a TruthTableEntry:
            TruthTableEntry ent = new TruthTableEntry 
                {
                    A = (i & (1 >> (NumInputs - 1))) != 0,
                    B = (i & (1 >> (NumInputs - 2))) != 0,
                    C = (i & (1 >> (NumInputs - 3))) != 0,
                    D = (i & (1 >> (NumInputs - 4))) != 0,
                    Out = false,
                };
            res.Add(ent);
        }
        return res;
    }
