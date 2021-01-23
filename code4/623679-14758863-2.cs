Reason you get so many Messages is because the MessageBox.Show() is inside the foreach loop just put it outside the loop and you will only see one.
        private void btnExit_Click(object sender, EventArgs e)
        {
            // TODO: add code that displays dialog boxes here
            string totalstring = "";
            foreach (decimal value in decArray)
            {
                totalstring += value + "\n";
            }
            MessageBox.Show(totalstring + "\n", "Order Totals");
            this.Close();
        }
