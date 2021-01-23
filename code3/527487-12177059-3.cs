            private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            //key up or key down
            if (e.Key == Key.Up || e.Key == Key.Down)
            {
                //has 2 items
                if (comboBox1.Items.Count == 2)
                {
                    if (comboBox1.SelectedIndex == 0)
                        comboBox1.SelectedIndex = 1;
                    else
                        comboBox1.SelectedIndex = 0;
                }
            }
        }
