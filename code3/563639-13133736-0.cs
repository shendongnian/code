    public partial class Form1 : Form
    {
        int runningTotal;
        int roll1;
        int maxRolls;
        int rollCount;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (maxRolls == 0)
            {
                Random getMax = new Random();
                rollagainLabel.Visible = false;
                maxRolls = getMax.Next(10) ;
            }
            else 
                if(rollCount >= maxRolls)
                {
                    maxRolls = 0;
                    rollagainLabel.Visible = true;
                    rollCount = 0;
                    runningTotal = 0;
                    totalmoneyLabel.Text = "$0.0";
                    return; 
                }
            
            Random rand = new Random();
            roll1 = rand.Next(6) + 1;
            int value = 100;
            int sum = (roll1 * value);
            runningTotal += sum;
            totalmoneyLabel.Text = runningTotal.ToString("c");
            rollCount += 1;
                      
            if (roll1 == 1)
            {
                    //diceBox1.Image = GAME.Properties.Resources._1Die;
            }
        }
    }
