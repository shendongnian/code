	private void SetText(string text)
	{
		if (this.txtOutput.InvokeRequired)
		{
			SetTextCallback d = new SetTextCallback(SetText);
			this.BeginInvoke(d, new object[] { text });
		}
		else
		{
			txtOutput.AppendText(text);
			string a="", b="", c="";
			string invia = text.ToString();
			Stripper strp = new Stripper();
			strp.Distri(invia, out a, out b, out c);
			textBox7.Text = a; // Current
			textBox2.Text = b; //Temperature
			textBox6.Text = c; //RPM
		}
	}			
