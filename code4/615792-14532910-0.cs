      DataGridViewRow RowSample = new DataGridViewRow();
      DataGridViewComboBoxCell  pizzaItem = new DataGridViewComboBoxCell();
      pizzaItem.DataSource = pizzaList_;  
      pizzaItem.Value = pizzaList_[0];
      DataGridViewCell pizzaName = new DataGridViewTextBoxCell();
      pizzaName.Value = pizza.pizzaName; // creating the text cell
      DataGridViewCell pizzaPrice = new DataGridViewTextBoxCell();
      pizzaPrice.Value = pizza.pizzaPrice;; // creating the text cell
      RowSample.Cells.Add(pizzaName);
      RowSample.Cells.Add(pizzaPrice);
      RowSample.Cells.Add(pizzaItem); 
      SampleGridView.Rows.Add(RowSample);
    
