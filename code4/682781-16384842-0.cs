    private void btnSearchName_Click(object sender, EventArgs e)
        {
            Int32 counter = 0;
            try
            {
                foreach (SalesmanDetails search in salesmanList)
                {
                    if (search.firstName.ToLower().Contains(searchName.ToLower()) | search.surname.ToLower().Contains(searchName.ToLower()))
                    {
                        listBox1.Items.Add(String.Format("{0} {1}", search.firstName, search.surname));
                        myList.Add(counter);
                    }
                    counter++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
