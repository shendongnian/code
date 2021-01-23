    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            go();
        }
    
        void go()
        {
            int[] numbers = new int[8];
            Random random = new Random();
    
            for (int i = 0; i < 8; i++)
            {
                numbers[i] = random.Next(10, 1000);
            }
    
            label1.Text = numbers[0].ToString();
            label2.Text = numbers[1].ToString();
            label3.Text = numbers[2].ToString();
            label4.Text = numbers[3].ToString();
            label5.Text = numbers[4].ToString();
            label6.Text = numbers[5].ToString();
            label7.Text = numbers[6].ToString();
            label8.Text = numbers[7].ToString();
        }
    }
