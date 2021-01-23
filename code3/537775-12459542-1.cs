     private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
     {
          Domicilio d = comboBox1.SelectedItem as Domicilio;
          if (d!=null)
          {
            txtCalle.Text = d.Calle;
            txtNumero.Text = d.Numero.ToString();
          }
     }
