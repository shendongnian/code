            block1.SetValue(TextBlock.ForegroundProperty, Brushes.Red);
            Binding binding1 = new Binding();
            binding1.Path = new PropertyPath("Titolo");
            block1.SetBinding(TextBlock.TextProperty, binding1);
            block2.SetValue(TextBlock.ForegroundProperty, Brushes.Red);
            Binding binding2 = new Binding();
            binding2.Path = new PropertyPath("noteDateCreated");
            block2.SetBinding(TextBlock.TextProperty, binding2);         
      
            spOuterFactory.AppendChild(block1);
            spOuterFactory.AppendChild(block2);
            template.VisualTree = spOuterFactory;
            noteListBox.ItemTemplate = template;
