    private void buttonOK_Click(object sender, EventArgs e) {
            try {
                bool inputTest;
                decimal amount;
                inputTest = decimal.TryParse(textBoxAmount.Text, out amount);
                if (inputTest == false) {
                    throw new InvalidTransactionAmtException();
                } else {
                    BankAccount account = comboBoxAccount.SelectedItem as BankAccount;
                    deposit = new DepositTransaction(account, amount);
                    deposit.DoTransaction();
                    this.DialogResult = DialogResult.OK;
                }
            //catch any type of exception here
            } catch (Exception ex) {
                errorProviderDeposit.SetError(textBoxAmount, ex.Message);
                textBoxAmount.Select();
                textBoxAmount.SelectAll();
            }
        }
