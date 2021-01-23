			private DocumentPageView _PageView;
			public DocumentPaginator CustomDocumentPaginator { get; private set; }
			public override void OnApplyTemplate()
			{
				base.OnApplyTemplate();
				_PageView = (DocumentPageView)GetTemplateChild("DocumentPageView_1");
				if (_PageView != null) _PageView.DocumentPaginator = CustomDocumentPaginator;
			}
			protected override void OnDocumentChanged()
			{
				base.OnDocumentChanged();
				var doc = Document as FlowDocument;
				CustomDocumentPaginator = doc == null ? null : new DocumentPaginatorWrapper((doc as IDocumentPaginatorSource).DocumentPaginator, new Thickness { Bottom = 32 /* 0.333in */ });
				if (_PageView != null) _PageView.DocumentPaginator = CustomDocumentPaginator;
			}
