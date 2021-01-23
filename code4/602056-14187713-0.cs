        public void Test()
        {
            ArrayList info = new ArrayList();
            info.Add(new CarInfo { CarLiscen = 123456, CarNo = 123});
            info.Add(new CarInfo { CarLiscen = 234567, CarNo = 234 });
            cboCars.DataSource = info;
            cboCars.DisplayMember = "CarLiscen";
            cboCars.ValueMember = "CarNo";
            cboCars.SelectedValueChanged +=
                delegate(object sender, EventArgs e)
                {
                    if (cboCars.SelectedIndex != -1)
                    {
                        this.Text = cboCars.SelectedValue.ToString();
                    }
                };
            cboCars.SelectedValue = 234;
        }
