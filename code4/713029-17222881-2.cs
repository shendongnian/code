	private void textBox1_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyData == Keys.OemPeriod && textBox1.Text.Length == 0)
		{
			i = 0;
			e.SuppressKeyPress = true;
			secret = true;
			textBox1.Text += normal[i];
			textBox1.Select(textBox1.Text.Length, 0);
			i++;
			answer = null;
		}
		else if (e.KeyData == Keys.OemPeriod && secret == true)
		{
			e.SuppressKeyPress = true;
			textBox1.Text += normal[i];
			secret = false;
			textBox1.Select(textBox1.Text.Length, 0);
			secret2 = true;
		}
		else if(e.KeyData != Keys.OemPeriod && secret == true && e.KeyData != Keys.Back && Control.ModifierKeys != Keys.Shift  && e.KeyData != Keys.Space)
		{
			e.SuppressKeyPress = true;
			answer += e.KeyData;
			textBox1.Text += normal[i];
			textBox1.Select(textBox1.Text.Length, 0);
			i++;
		}
		else if (e.KeyData == Keys.Back && secret == true)
		{
			string petition = textBox1.Text;
			if (petition.Length != 0)
			{
				if (petition.Length > 1)
				{
					petition = petition.Remove(petition.Length - 1);
					answer = answer.Remove(answer.Length - 1);
					i--;
				}
				else if (petition.Length == 1)
				{
					petition = petition.Remove(petition.Length - 1);
					i--;
					secret = false;
					secret2 = false;
					answer = null;
				}
				else if (answer.Length > 0)
				{
					answer = answer.Remove(answer.Length - 1);
				}
				else if (answer.Length <= 0)
				{
					answer = null;
				}
			}
		}
		else if (e.KeyData == Keys.Space && secret == true)
		{
			e.SuppressKeyPress = true;
			answer += " ";
			textBox1.Text += normal[i];
			textBox1.Select(textBox1.Text.Length, 0);
			i++;
		}
		else if (Control.ModifierKeys == Keys.Shift && secret == true)
		{
			e.SuppressKeyPress = true;
			textBox1.Select(textBox1.Text.Length, 0);
		}
	}
