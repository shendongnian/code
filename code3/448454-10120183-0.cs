    foreach (FileInfo s in fis)
            {
                ugModels.Children.Add(new Button()
                {
                    Background = ThemeColour,
                    //          This Fixed the problem           //
                    RenderTransform = new TransformGroup()
                    {
                        Children = new TransformCollection()
                        {
                            new ScaleTransform(),
                            new SkewTransform(),
                            new RotateTransform(),
                            new TranslateTransform()
                        }
                    },                
                    ////////////////////////////////////////////////
                    BorderBrush = null,
                    Foreground = new SolidColorBrush(Colors.White),
                    Name = "btn" + s.Name.Split('.')[0].Replace(" ", ""),
                    Margin = new Thickness(12, 12, 12, 12),
                    FontSize = 48,
                    Style = MainButtonStyle,
                    Content = s.Name.Split('.')[0]
                });
            }    
