    private void OnSeriesSourceChanged(IEnumerable oldValue, IEnumerable newValue)
    {
        this.Series.Clear();
        if (newValue != null)
        {
            foreach (object item in newValue)
            {
                if (SeriesTemplate != null)
                {
                    ChartSeries series = LoadDataTemplate<ChartSeries>(SeriesTemplate, item);
                    if (series != null)
                    {
                        // set data context
                        series.DataContext = item;
                        this.Series.Add(series);
                    }
                }
            }
        }
        UpdateGroupedSeries();
    }
    private static T LoadDataTemplate<T>(DataTemplate template, object dataContext)
        where T : FrameworkElement
    {
        DependencyObject element = template.LoadContent();
        T view = element as T;
        view.DataContext = dataContext;
        var enumerator = element.GetLocalValueEnumerator();
        while (enumerator.MoveNext())
        {
            var bind = enumerator.Current;
            if (bind.Value is BindingExpression)
            {
                view.SetBinding(bind.Property, ((BindingExpression)bind.Value).ParentBinding);
            }
        }
        return view;
    }
