        private bool _canUpdate = true;
        private bool _needUpdate = false;
        List<spIskalnikNaslovi_Result1> dataFound;
        private void comboBox12_TextChanged(object sender, EventArgs e)
        {
            if (_needUpdate)
            {
                if (_canUpdate)
                {
                    _canUpdate = false;
                    refreshData();
                }
                else
                {
                    restartTimer();
                }
            }
        }
        private void comboBox12_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                int searchStart = comboBox12.SelectionStart;
                if (searchStart > 0)
                {
                    searchStart--;
                    if (searchStart == 0)
                    {
                        comboBox12.Text = "";
                    }
                    else
                    {
                        comboBox12.Text = comboBox12.Text.Substring(0, searchStart + 1);
                    }
                }
                else 
                {
                    searchStart = 0;
                }
                e.Handled = true;
            }
        }
        private void comboBox12_TextUpdate(object sender, EventArgs e)
        {
            _needUpdate = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            _canUpdate = true;
            timer1.Stop();
            refreshData();
        }
        private void refreshData()
        {
            if (comboBox12.Text.Length > 1)
            {
                FillCombobox(comboBox12.Text, comboBox12);
            }
        }
        private void restartTimer()
        {
            timer1.Stop();
            _canUpdate = false;
            timer1.Start();
        }
        private void FillCombobox(string value, ComboBox myCombo)
        {
            dataFound = _vsebina.spIskalnikNaslovi1(value).ToList();
            if (dataFound.Count() > 0)
            {
                myCombo.DataSource = dataFound;
                myCombo.ValueMember = "HS_MID";
                myCombo.DisplayMember = "NASLOV1";
                var searchedItem = myCombo.Items[0].ToString();
                myCombo.SelectionStart = value.Length;
                myCombo.SelectionLength = searchedItem.Length - value.Length;
                myCombo.DroppedDown = true;
                return;
            }
            else
            {
                myCombo.DroppedDown = false;
                myCombo.SelectionStart = value.Length;
                return;
            }            
        }
