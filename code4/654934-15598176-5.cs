            GroupStyle g = new GroupStyle();
            //Create header template
            FrameworkElementFactory control = new
                                      FrameworkElementFactory(typeof(TextBlock));
            Binding binding = new Binding();
            control.SetBinding(TextBlock.TextProperty, binding);
            binding.Path = new PropertyPath("Name");
            DataTemplate dataTemplate = new DataTemplate();
            dataTemplate.VisualTree = control;
            g.HeaderTemplate = dataTemplate;
            ComboBox cmb = new ComboBox();
            cmb.GroupStyle.Add(g);
