    for (int i = 0; i < preventivoView.Rows.Count; i++)
     {
            if(preventivoView.SelectedRow != null)
                {            
                BudgetCommessa budgetCommessa = new BudgetCommessa();
                budgetCommessa.Task = Convert.ToString(preventivoView.SelectedRow.Cells[0].Text);//SelectedDataKey.Values[0]);
                listaDaGridView.Add(budgetCommessa);
                }
     }
