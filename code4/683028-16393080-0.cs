            var headerStyle = new Style();
            Setter fontSetter = new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Calibri") };
            headerStyle.Setters.Add(fontSetter);
            
            Setter fontSizeSetter = new Setter { Property = Control.FontSizeProperty, Value = Convert.ToDouble(20) };
            headerStyle.Setters.Add(fontSizeSetter);
            
            Setter fontStyleSetter = new Setter { Property = Control.FontStyleProperty, Value = FontStyles.Italic };
            headerStyle.Setters.Add(fontStyleSetter);
            Setter fontWeightSetter = new Setter { Property = Control.FontWeightProperty, Value = FontWeights.Bold };
            headerStyle.Setters.Add(fontWeightSetter);
            
            myGrid.ColumnHeaderStyle = headerStyle;
