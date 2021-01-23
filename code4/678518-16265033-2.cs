        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                IList<HRData> data = HRDataReader.Read(openFileDialog1.FileName);
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "HeartRate", HeaderText = "Heart rate", DataPropertyName = "HeartRate" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Speed", HeaderText = "Speed", DataPropertyName = "Speed" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Power", HeaderText = "Power", DataPropertyName = "Power" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Altitude", HeaderText = "Altitude", DataPropertyName = "Altitude" });
                dataGridView1.DataSource = data;
                label1.Text = data.MaximumAltitude().ToString();
                textBox1.Text = data.MaximumSpeed().ToString();
                textBox2.Text = data.AverageSpeed().ToString();
                textBox3.Text = data.AverageHeartRate().ToString();
                textBox4.Text = data.MaximumHeartRate().ToString();
                textBox5.Text = data.MinimumHeartRate().ToString();
                textBox6.Text = data.AveragePower().ToString();
                textBox7.Text = data.MaximumPower().ToString();
                textBox8.Text = data.AverageAltitude().ToString();
                textBox9.Text = data.MaximumAltitude().ToString();
            }
        }
