    // Create the Grid
                Grid myGrid = new Grid();
                myGrid.Width = 400;
                myGrid.Margin = new Thickness(9, 0, 0, 0);
                myGrid.HorizontalAlignment = HorizontalAlignment.Left;
                myGrid.VerticalAlignment = VerticalAlignment.Top;
                myGrid.ShowGridLines = true;
                // Define the Columns
                ColumnDefinition colDef1 = new ColumnDefinition();
                ColumnDefinition colDef2 = new ColumnDefinition();
                ColumnDefinition colDef3 = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(colDef1);
                myGrid.ColumnDefinitions.Add(colDef2);
                myGrid.ColumnDefinitions.Add(colDef3);
                // Define the Rows
                RowDefinition rowDef1 = new RowDefinition();
                RowDefinition rowDef2 = new RowDefinition();
                RowDefinition rowDef3 = new RowDefinition();
                RowDefinition rowDef4 = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef1);
                myGrid.RowDefinitions.Add(rowDef2);
                myGrid.RowDefinitions.Add(rowDef3);
                myGrid.RowDefinitions.Add(rowDef4);
                // Add the second text cell to the Grid
                TextBlock txtBeneficialOwner = new TextBlock();
                txtBeneficialOwner.Text = "Beneficial Owner";
                txtBeneficialOwner.FontWeight = FontWeights.Bold;
                Grid.SetRow(txtBeneficialOwner, 0);
                Grid.SetColumn(txtBeneficialOwner, 0);
                // Add the third text cell to the Grid
                TextBlock txtCommercialOperator = new TextBlock();
                txtCommercialOperator.Text = "Commercial Operator";
                txtCommercialOperator.FontWeight = FontWeights.Bold;
                txtCommercialOperator.Margin = new Thickness(9, 0, 0, 4);
                Grid.SetRow(txtCommercialOperator, 0);
                Grid.SetColumn(txtCommercialOperator, 1);
                // Add the fourth text cell to the Grid
                TextBlock txtRegisteredOwnerName = new TextBlock();
                txtRegisteredOwnerName.Text = "Registered Owner";
                txtRegisteredOwnerName.FontWeight = FontWeights.Bold;
                txtRegisteredOwnerName.Margin = new Thickness(9, 0, 0, 4);
                Grid.SetRow(txtRegisteredOwnerName, 0);
                Grid.SetColumn(txtRegisteredOwnerName, 2);
                // Add the TextBlock elements to the Grid Children collection
                myGrid.Children.Add(txtBeneficialOwner);
                myGrid.Children.Add(txtCommercialOperator);
                myGrid.Children.Add(txtRegisteredOwnerName);
                stackPanelSearchResults.Children.Add(myGrid);
