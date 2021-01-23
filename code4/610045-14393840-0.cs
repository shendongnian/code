        // ValueChanged Event
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date == DateTime.Now.Date)
            {
                MessageBox.Show("Hola !!");
            }
        }
