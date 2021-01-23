                try
            {
                //Create Client
                ServiceReference1.TempConvertSoapClient client = new ServiceReference1.TempConvertSoapClient(binding, endpoint);
                if (client.ClientCredentials != null)
                {
                    //Use Values which are typed in in the GUI
                    string user = tbUser.Text;
                    string password = tbPassword.Text;
                    string domain = tbDomain.Text;
                    client.ClientCredentials.UserName.UserName = user;
                    client.ClientCredentials.UserName.Password = password;
                    client.ClientCredentials.Windows.ClientCredential.Domain = domain;
                    //Check what information is used by the customer.
                    if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(domain))
                    {
                        client.ClientCredentials.Windows.ClientCredential = new NetworkCredential(user, password, domain);
                    }
                    if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
                    {
                        client.ClientCredentials.Windows.ClientCredential = new NetworkCredential(user, password);
                    }
                }
                //Oh nooo... no temperature typed in
                if (string.IsNullOrEmpty(tbFahrenheit.Text))
                {
                    //GOOD BYE
                    return;
                }
                //Use the webservice 
                
                //THIS ONE IS IMPORTANT
                System.Net.ServicePointManager.Expect100Continue = false;
                string celsius =  client.FahrenheitToCelsius(tbFahrenheit.Text); //<-- Simple Calculation
                tbCelsius.Text = celsius;
            }
            catch(Exception ex) 
            {
                //Something 
                tbCelsius.Text = ex.Message;
                MessageBox.Show(ex.ToString());
            }
            
        }
