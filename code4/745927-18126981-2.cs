        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                POT = serialPort1.ReadExisting();
                textBox1.Text = POT.ToString();
            }
            if (! double.TryParse(textBox1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out f)) return;
            f = Convert.ToDouble(textBox1.Text);
            lista.Add(f);
            i++;
            if (i == lista.Capacity)
            {
                lista.Capacity = lista.Capacity + 100;
            }
        }
