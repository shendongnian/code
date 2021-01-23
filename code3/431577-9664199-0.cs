    for (int i = 0; i < DataRepository.Categories.Categories.Count; i++)
    {
        CategoriesDataSet.CategoriesRow category = DataRepository.Categories.Categories[i];
            if (!category.CategoryName.Equals("ROOT"))
            {
                SimpleButton button = new SimpleButton();
                button.Text = category.CategoryName;
                button.Tag = category.CategoryId;
                button.Size = new Size(82, 70);
                button.Left = i%4*82;
                button.Top = i*70;
                button.Click += CategoryButtonClick;
                categoriesPanel.Controls.Add(button);
            }
        }
