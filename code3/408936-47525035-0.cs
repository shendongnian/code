        private void SetRowHeight(double height)
        {
            Style style = new Style();
            style.Setters.Add(new Setter(property: FrameworkElement.HeightProperty, value: height));
            this.RowStyle = style;
        }
