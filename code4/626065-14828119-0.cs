    private void button5_Click(object sender, EventArgs e)
        {
            //Agregar
            arreglo.Add(textBox1.Text.ToString());
            if (arreglo.Count > 10)
            {
                button5.Enabled = false;
            }
            this.textBox1.Clear();
            this.textBox1.Focus();
        }
