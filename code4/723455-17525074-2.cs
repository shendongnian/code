    private static DataTemplate TreeViewDataTemp
        {
            get
            {
                DataTemplate TVDT = new DataTemplate();
                FrameworkElementFactory Stack = new FrameworkElementFactory(typeof(StackPanel));
                Stack.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
                FrameworkElementFactory TextB = new FrameworkElementFactory(typeof(TextBlock));
                TextB.SetValue(TextBlock.TextProperty, new Binding());
                FrameworkElementFactory ChkBox = new FrameworkElementFactory(typeof(CheckBox));
                Stack.AppendChild(TextB);
                Stack.AppendChild(ChkBox);
                TVDT.VisualTree = Stack;
                return TVDT;
            }
        }
