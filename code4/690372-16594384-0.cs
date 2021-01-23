        public Form1()
        {
            InitializeComponent();
            list = new List<CheckBox>();
        }
        List<CheckBox> list;
        Menu menu;
        private void Form1_Load(object sender, EventArgs e)
        {
            menu = new Menu();
            int i = 10;
            foreach(var item in menu.pizza){
                CheckBox checkBox = new CheckBox();
                checkBox.Text = item;
                checkBox.Location = new System.Drawing.Point(10, i);
                i = i + 30;
                list.Add(checkBox);
                panel1.Controls.Add(checkBox);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list.Count;i++ )
            {
                if (list[i].Checked)
                {
                    label1.Text += menu.GetMenuItem(i);
                }
            }
        }
    }
