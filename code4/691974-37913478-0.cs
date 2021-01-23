	private void buttonl_Click(object sender, EventArgs e) 
	{ 
		String url = TextBox_url.Text;
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url); 
		HttpWebResponse response = (HttpWebResponse) request.GetResponse(); 
		StreamReader sr = new StreamReader(response.GetResponseStream()); 
		richTextBox1.Text = sr.ReadToEnd(); 
		sr.Close(); 
	} 
