    if (e.Key == Key.Enter && !string.IsNullOrWhiteSpace(txtPass.Text))
            {
                if (1 + 1 != 3)
                {
                    MessageBox.Show("Wrong!!!");
                    txtPass.Clear();
                    txtPass.Focus();
                }
            }
