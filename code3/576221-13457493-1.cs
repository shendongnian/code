     // Editing Template for when you edit the DataCell in the DataGridColumn
     // Create a Data Template for when you are displaying a DataGridColumn
     DataTemplate textBoxTemplate = new DataTemplate();
     // Create a Framework Element for the DataGrid Column type (In this case, TextBox so the user can type)
     FrameworkElementFactory textBoxElement = new FrameworkElementFactory(typeof(TextBox));
     // Create a Binding to the value being edited in the DataGridColumn
     Binding textBoxBinding = new Binding("myPropertyName");
     // Assign the Binding to the Text Property of the TextBox
     textBoxElement.SetBinding(TextBox.TextProperty, textBoxBinding);
     // Set the DataGridColumn to stretch to fit the text
     textBlockElement.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Stretch);
     // Add the TextBox element to the Visual Tree of the Data Template
     textBoxTemplate.VisualTree = textBoxElement;
     // Add the Data Template to the DataGridColumn Cell Editing Template
     templatecolumn.CellEditingTemplate = textBoxTemplate;
     
