            string ProductID = deleteProductButton.Text;
            if (string.IsNullOrEmpty(ProductID))
            {
                MessageBox.Show("Please enter valid ProductID");
                deleteProductButton.Focus();
            }
            try
            {
                string SelectDelete = "Delete from Products where ProductID=" + deleteProductButton.Text;
                SqlCommand command = new SqlCommand(SelectDelete, Conn);
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 15;
                DialogResult comfirmDelete = MessageBox.Show("Are you sure you want to delete this record?");
                if (comfirmDelete == DialogResult.No)
                {
                    return;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
