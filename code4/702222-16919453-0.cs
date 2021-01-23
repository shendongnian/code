     TextBox tx = e.Control as TextBox;
     DataGridViewTextBoxCell cell = prol04DataGridView.CurrentCell as DataGridViewTextBoxCell;
     if (tx != null && cell != null && cell.OwningColumn == prol04DataGridView.Columns[5])
     {
           tx.TextChanged -= new EventHandler(tx_TextChanged);
           tx.TextChanged += new EventHandler(tx_TextChanged);
     }
