        private void Form1_Load(object sender, EventArgs e)
        {
            Int32 x = 20;
            Int32 y = 20;
            for (Int32 i = 0; i < 20; i++)
            {
                Button btn = new Button();
                btn.Name = "btn" + i.ToString();
                btn.Location = new Point(x, y);
                x = x + 20;
                panel1.Controls.Add(btn);
            }
            //call(1, new List<long> { 1, 2, 3, 4 });
        }
        private void **panel1_Scroll**(object sender, ScrollEventArgs e)
        {
            MessageBox.Show("scroll");
        }
     panel control have its own method "Scroll" see events of panel control and find the "Scroll"....
