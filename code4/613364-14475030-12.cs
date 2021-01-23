	DataGridTemplateColumn imgColumn = new DataGridTemplateColumn();
	imgColumn.Header = "Image";
	FrameworkElementFactory imageFactory = new FrameworkElementFactory(typeof(Image));
	imageFactory.SetBinding(Image.SourceProperty, new Binding("ImgPath"));
	DataTemplate dataTemplate = new DataTemplate();
	dataTemplate.VisualTree = imageFactory;
	imgColumn.CellTemplate = dataTemplate;
	DGImages.Columns.Add(imgColumn);
