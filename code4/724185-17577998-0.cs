    string Str = txtMemberNr.Text.Trim();
                double Num;
                bool isNum = double.TryParse(Str, out Num);
                if (isNum)
                {
                  // CODE IS HERE
                }
                else
                {
                    MessageBox.Show("Brugernavn skal kun indeholde tal, prøv igen!", "advarsel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
