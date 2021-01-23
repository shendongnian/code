       private class Browser {
            public string Name { get; set; }
            public string Exe { get; set; }
            public override string ToString() {
                return Name;
            }
        }
        private List<Browser> Browsers;
        private void Form1_Load(object sender, EventArgs e) {
            Browsers = new List<Browser>();
            const string browserListKey = @"SOFTWARE\Clients\StartMenuInternet";
            using (var clients = Registry.LocalMachine.OpenSubKey(browserListKey)) {
                foreach (var client in clients.GetSubKeyNames()) {
                    using (var clientKey = clients.OpenSubKey(client)) {
                        string name = (string)clientKey.GetValue(string.Empty);
                        using (var commandKey = clientKey.OpenSubKey(@"shell\open\command")) {
                            string exe = (string)commandKey.GetValue(string.Empty);
                            Browsers.Add(new Browser() { Name = name, Exe = exe });
                        }
                    }
                }
            }
            comboBox1.DataSource = Browsers;
        }
        private void button1_Click(object sender, EventArgs e) {
            string exe = ((Browser)comboBox1.SelectedItem).Exe;
            Process.Start(exe);
        }
