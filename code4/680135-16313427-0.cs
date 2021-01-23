    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnAdd.Enabled = false;
        }
        int[] weight;
        int entriesMade;
        int numOfPackages;
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (int.TryParse(numEntriesBox.Text, out numOfPackages))
            {
                weight = new int[numOfPackages];
                entriesMade = 0;
                btnReset.Enabled = false;
                btnAdd.Enabled = true;
                totalCostLabel.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid Number of Entries");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(weightBox.Text, out value))
            {
                weight[entriesMade] = value;
                weightBox.Clear();
                totalCostLabel.Text = "";
                int total = 0;
                for (int i = 0; i <= entriesMade; i++)
                {
                    total = total + weight[i];
                    if (i == 0)
                    {
                        totalCostLabel.Text = weight[i].ToString();
                    }
                    else
                    {
                        totalCostLabel.Text += " + " + weight[i].ToString();
                    }
                }
                totalCostLabel.Text += " = " + total.ToString();
                entriesMade++;
                if (entriesMade == numOfPackages)
                {
                    btnAdd.Enabled = false;
                    btnReset.Enabled = true;
                    MessageBox.Show("Done!");
                }
            }
            else
            {
                MessageBox.Show("Invalid Weight");
            }
        }
    }
