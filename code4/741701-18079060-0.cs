            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
                _elementName = Template.FindName("PART_ElementName", this) as TextBlock;
                _elementText = Template.FindName("PART_ElementText", this) as TextBlock;
    
                if (_elementName != null) _elementName.MouseLeftButtonDown += (sender, args) => SelectControl();
                if (_elementText != null) _elementText.MouseLeftButtonDown += (sender, args) => SelectControl();
            }
