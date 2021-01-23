      private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           MessageBox.Show("The value in the bar comboBox is "+ comboBox1.Text);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("The value in the bar comboBox is "+ listBox1.Text);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            WebServiceRef.CM_ServiceSoapClient soapClient = new WebServiceRef.CM_ServiceSoapClient();
            comboBox1.DataSource = soapClient.GetAllCategories();
            listBox1.DataSource = soapClient.GetAllCategories();
        }
