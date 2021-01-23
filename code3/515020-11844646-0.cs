     Rectangle TrackLoaded;
        public override void OnApplyTemplate() {
          base.OnApplyTemplate();
          Rectangle txtBoxValue = base.GetTemplateChild("HorizontalFillLoaded") as Rectangle;
    
          Binding valueBinding = new Binding("TrackProgressWidth");
          valueBinding.Mode = BindingMode.TwoWay;
          valueBinding.Source = this; txtBoxValue.SetBinding(Rectangle.WidthProperty,
           valueBinding);
        }
