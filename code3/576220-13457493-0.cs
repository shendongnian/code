     // Displaying Template for when you display the DataCell in the DataGridColumn
     // Create a Data Template for when you are displaying a DataGridColumn
     DataTemplate textBlockTemplate = new DataTemplate();
     // Create a Framework Element for the DataGridColumn type (In this case, a TextBlock)
     FrameworkElementFactory textBlockElement = new FrameworkElementFactory(typeof(TextBlock));
     // Create a Binding to the value being displayed in the DataGridColumn
     Binding textBlockBinding = new Binding("myPropertyName");
     // Assign the Binding to the Text Property of the TextBlock
     textBlockElement.SetBinding(TextBlock.TextProperty, textBlockBinding);
     // Set the DataGridColumn to stretch to fit the text
     textBlockElement.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Stretch);
     // Add the TextBlock element to the Visual Tree of the Data Template
     textBlockTemplate.VisualTree = textBlockElement;
     // Add the Data Template to the DataGridColumn Cell Template
     templatecolumn.CellTemplate = textBlockTemplate;
