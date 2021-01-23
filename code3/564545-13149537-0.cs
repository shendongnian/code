    ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(lstClientes);
    selectedItems = lstClientes.SelectedItems;
    if (lstClientes.SelectedIndex != -1)
    { 
        for (int i = selectedItems.Count - 1; i >= 0; i++)
            lstClientes.Items.Remove(selectedItems[i]);
    }
    else
        MessageBox.Show("Debe seleccionar un email");
