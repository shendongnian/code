        List<Seat> seats;
        private void button6_Click(object sender, EventArgs e)
        {
            seats = new List<Seat>
            {
                new Seat { Identifier = "A1", Description = "A1 - Window" },
                new Seat { Identifier = "A2", Description = "A2 - Center" },
                new Seat { Identifier = "A3", Description = "A3 - Aisle" } 
            };
            listBox1.DataSource = seats;
            listBox1.DisplayMember = "Description";
            listBox1.ValueMember = "Identifier"; 
        }
        private void button7_Click(object sender, EventArgs e)
        {
            // get selected seat
            foreach (Seat selectedSeat in listBox1.SelectedItems)
            {
                MessageBox.Show(selectedSeat.Identifier);
            }
        }
