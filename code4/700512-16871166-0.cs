       private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			int asciiCode = Convert.ToInt32(e.KeyChar);
			if ((asciiCode >= 48 && asciiCode <= 57))
			{
			}
			else
	 	   {				MessageBox.Show("Not allowed!");
				e.Handled = true;
			}
		}
