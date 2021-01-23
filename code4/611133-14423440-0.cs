    private void button1_Click_1(object sender, EventArgs e)
    {
        List<RentalCar> listBox1snew = new List<RentalCar>();
        for (int i = 0; i < listBox1s.Count; i++)
        {
            if (DateTime.Now.Subtract(listBox1s[i].WOF).Days <= 7)
            {
                // Copy from listBox1s to listBox1snew
                listBox1new.Add(listBox1s[i]);
            }
        }
        // Use listBox1new as new data source
        listBox1.DataSource = listBox1new;
    }
