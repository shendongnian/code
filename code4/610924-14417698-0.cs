        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //var ix = tbxConvertito.Text.IndexOf(',');
            decimal myDecimal = 0;
            bool IsDecimal = decimal.TryParse(tbxConvertito.Text, out myDecimal);
            if (IsDecimal)
            {
                decimal letDivide = myDecimal / 100;
                int decimalPlace = (int)numericUpDown1.Value;
                tbxConvertito.Text = letDivide.ToString().Replace(".", "");
                var index = tbxConvertito.Text.Length - decimalPlace;
                if (index > -1)
                    tbxConvertito.Text = tbxConvertito.Text.Insert(index, ",");
                else
                    tbxConvertito.Text = tbxConvertito.Text.Insert(1, ",");
            }
            else
            {
                tbxConvertito.Text = tbxConvertito.Text.ToString().Replace(",", "");
            }
        }
