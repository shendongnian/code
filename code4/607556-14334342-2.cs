    for (int i = 0; i < preventivoView.Rows.Count; i++)
     {
        BudgetCommessa budgetCommessa = new BudgetCommessa();
        budgetCommessa.Task = Convert.ToString(preventivoView.Rows[i].Cells[0].Text);//SelectedDataKey.Values[0]);
        listaDaGridView.Add(budgetCommessa);
     }
