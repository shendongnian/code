    #region ReportName
		public string ReportName
		{
			get { return (string)GetValue(ReportNameProperty); }
			set { SetValue(ReportNameProperty, value); }
		}
		public static readonly DependencyProperty ReportNameProperty = DependencyProperty.Register("ReportName",
			typeof(string), typeof(ExportableGridView), new PropertyMetadata("Report", new PropertyChangedCallback(OnReportNameChanged)));
		public static void OnReportNameChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			ExportableGridView control = sender as ExportableGridView;
			control.titleTextBlock.Text = e.NewValue as string;
		}
	#endregion ReportName
