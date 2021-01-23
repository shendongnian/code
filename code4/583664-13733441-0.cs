    try
    {
        Validate();
        myBindingSource.MoveNext();
    }
    catch
    {
        if (MessageBox.Show("Do you want to keep editing the record?", "Error",
            MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
        {
            myBindingSource.CancelEdit();
        }
        else
        {
            foreach (Binding b in myBindingSource.CurrencyManager.Bindings)
                    {
                        b.WriteValue();
                    }
        }                
    }
