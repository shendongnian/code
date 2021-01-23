        public static List<string> lst=new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
              if (lst != null)
                listBox1.DataSource = lst;
        }
    }
