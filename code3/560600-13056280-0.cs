     int firstnum = Int32.Parse(txtboxnum.Text);
     int secondnum = Int32.Parse(txtboxnum2.Text);
     Random random = new Random();
     List<int> results = new List<int>();
     for (int i =0; i < 5; i++)
     {
         results.Add(random.Next(firstnum, secondnum));
     }
     answertxtbox.Text = String.Join(",", Array.ConvertAll<int, String>(results.ToArray(), Convert.ToString));
