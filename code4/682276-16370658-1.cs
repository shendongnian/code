        private void btnViewAll_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (SalesmanDetails details in salesmanList)
            {
                listBox1.Items.Add(String.Format("{0} {1}",details.firstName,details.surname));
            }
        }  
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
             int SalesmanDetailsIndex = listBox1.SelectedIndex;
             SalesmanDetails selectedSalesman=salesmanList[SalesmanDetailsIndex];
             MessageBox.Show(String.Format("{0} {1} email {2}",selectedSalesman.firstName,selectedSalesman.surname,selectedSalesman.email));
        }
