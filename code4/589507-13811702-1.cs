    public partial class Form1 : Form
    {
        ListBox lstFrequencies = new ListBox();
        int[] freq_array = new int[10];
        public Form1()
        {
            InitializeComponent();
            Size = new Size(400, 400);
            lstFrequencies.Location = new Point(150, 0);
            lstFrequencies.Size = new Size(150, 200);
            Controls.Add(lstFrequencies);
            int top = 0;
            for (int i = 0; i < 10; i++)
            {
                Button btn = new Button();
                btn.Size = new Size(70, 30);
                btn.Location = new Point(5, top);
                Controls.Add(btn);
                top += 35;
                btn.Tag = i;
                btn.Text = i.ToString();
                btn.Click += new EventHandler(btn_Click);
                lstFrequencies.Items.Add(i.ToString());
            }
        }
        void btn_Click(object sender, EventArgs e)
        {
            int clicked;
            clicked = int.Parse(((Button)(sender)).Text);
            freq_array[clicked]++;
            lstFrequencies.Items[clicked] = clicked + "\t\t" + freq_array[clicked]; //Cleaned up you do not need to iterate your list
                
            // Using my example code
            //if (int.TryParse(((Button)sender).Tag.ToString(), out clicked))
            //{
            //    freq_array[clicked]++;
            //    lstFrequencies.Items[clicked] = clicked + "\t\t" + freq_array[clicked];
            //} 
        }
    }
