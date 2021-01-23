    public void datagrid_Jobs_Loaded(object sender, EventArgs e)
    {
    	FrameworkElementFactory sliderHolder = new FrameworkElementFactory(typeof(Slider));
    	sliderHolder.SetBinding(Slider.ValueProperty, new Binding("Score") { UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
    	sliderHolder.SetValue(Slider.MarginProperty, new Thickness(5));
    	sliderHolder.SetValue(Slider.MaximumProperty, (double)100);
    	sliderHolder.SetValue(Slider.MinimumProperty, (double)0);
    	var dataTemplate = new DataTemplate();
    	dataTemplate.VisualTree = sliderHolder;
    	dataTemplate.DataType = typeof(DataGridTemplateColumn);
    	pcColumn.CellTemplate = dataTemplate;
    }
