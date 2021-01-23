    public void btnTransaction_Click(object sender, EventArgs e)
    {
        using (var transactionForm = new Transaction())
        {
          this.Hide();
          if (transactionForm.ShowDialog() == DialogResult.OK)
          {
              this.Show();
          }
        }
    }
