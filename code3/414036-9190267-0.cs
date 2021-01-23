      private void button1_Click(object sender, EventArgs e)
            {
                List<string> names=new List<string>(){"Forename","Email","Phone"};
                foreach (var name in names)
                {
                    var txt = this.Controls["text" + name] as TextBox;
                    txt.DataBindings.Add("Text", dtClients, name, true, DataSourceUpdateMode.OnPropertyChanged);
                }
            
            }
