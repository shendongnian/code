            // Property to bind (example)....
            public SolidColorBrush MyColor { get; set; }
            //
            // In some initialisation method.
            MyColor = new SolidColorBrush(Colors.Blue);
            Binding myBinding = new Binding("MyColor");
            MyRect.SetBinding(Rectangle.FillProperty, myBinding);
