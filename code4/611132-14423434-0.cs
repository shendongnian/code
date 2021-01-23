    private void button1_Click_1(object sender, EventArgs e)
        {
            List<RentalCar> listBox1snew = new List<RentalCar>();
            for (int i = 0; i < listBox1s.Count; i++)
            {
                if ((DateTime.Now - listBox1s[i].WOF).Days <= 7)
                {
                    listBox1snew .Items.Insert(0, listBox1s[i]);
        
                }
            }
            listBox1.DataSource = listBox1snew;//add car to listbox
        }
