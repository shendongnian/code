     public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
            {
                ContentPresenter cp = container as ContentPresenter;
                if (cp != null)
                {
                    CalculatorViewModel model = cp.DataContext as CalculatorViewModel;
                    if (model != null)
                    {
                        if (model.Mode is DefaultMode)
                            return DefaultView;
                        if (model.Mode is HexMode)
                            return HexView;
                    }
                }
                return base.SelectTemplate(item, container);
            }
