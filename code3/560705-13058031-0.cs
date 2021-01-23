    private void UpdateRecipeComboBox(string text)
    {
        if (this.recipeListComboBox.InvokeRequired)
        {
            UpdateRecipeComboBoxCallBack d = new UpdateRecipeComboBoxCallBack(UpdateRecipeComboBox);
            Invoke(d, new object[] { text });
        }
        else
        {
            this.recipeListComboBox.Items.Add(Text);  // <--- should be text???
        }
    }
