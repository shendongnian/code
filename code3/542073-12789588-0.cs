        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var data = TryLoad(dialog.FileName); ;
                    if (data != null)
                    {
                        myBindingSource.Add(data);
                    }
                }
            }
        }
