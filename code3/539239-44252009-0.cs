    private void btnAddRecipe_Click(object sender, EventArgs e)
    {
    bool DoesItemExist = false;
    string searchString = txtRecipeName.Text;
    int index = lstRecipes.FindStringExact(searchString, -1);
            if (index != -1) DoesItemExist = true;
            else DoesItemExist = false;
            if (DoesItemExist)
            {
               //do something
            }
            else
            {
                MessageBox.Show("Not found", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
            }
           
            PopulateRecipe();
        }
