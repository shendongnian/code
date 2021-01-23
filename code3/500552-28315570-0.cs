                object item = dataGrid1.SelectedItem;
                txtRegId.Text = (dataGrid1.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                MessageBox.Show(txtName.Text);
            }
    </pre>
