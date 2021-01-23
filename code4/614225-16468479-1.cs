        if (TheClass.validateForm(txtBox, txtBox2, listCheckList))
        {
            txtBox3.Text = TheClass.generateItem1(something, something2);
            txtBox4.Text = TheClass.generateItem2(something, something2, txtPath.Text, txtTitle.Text, listCheckList.GetItemChecked(5));
        }
        else
        {
            MessageBox.Show("Please check fields marked in red, if any. Double check your Check List required items.", "Title Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    
