    private void button9_Click(object sender, EventArgs e)
    {
        if(dataGridView4.DataSource is IEnumerable<T>){
          var result = ((IEnumerable<T>)dataGridView4.DataSource).Where(Srodek => Srodek.Srodek.ID.Device == textBox2.Text).ToList();
          dataGridView4.DataSource = result;
        }
    }
