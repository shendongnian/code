        private void button2_Click(object sender, EventArgs e)
        {
            BasicHttpBinding binding = new BasicHttpBinding("TempConvertSoap");
            if (!string.IsNullOrEmpty(tbProxy.Text))
            {
                binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
                binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.Basic;
                string proxy = string.Format("http://{0}", tbProxy.Text);
                if (!string.IsNullOrEmpty(tbPort.Text)) 
                {
                   proxy = string.Format("{0}:{1}",proxy,tbPort.Text);
                }
                binding.UseDefaultWebProxy = false;
                binding.ProxyAddress = new Uri(proxy);
            }
            EndpointAddress endpoint = new EndpointAddress(@"http://www.w3schools.com/webservices/tempconvert.asmx");
