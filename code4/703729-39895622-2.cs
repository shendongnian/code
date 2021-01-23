		class DocumentPaginatorWrapper : DocumentPaginator
		{
			private Thickness _Margin;
			private DocumentPaginator _Paginator;
			// Required to avoid "ArgumentException: Specified Visual is already a child of another Visual or the root of a CompositionTarget" when printing
			private IDictionary<int, DocumentPage> _PageCache = new Dictionary<int, DocumentPage>();
			public DocumentPaginatorWrapper(DocumentPaginator paginator, Thickness margin)
			{
				_Margin = margin;
				_Paginator = paginator;
				this.PageSize = paginator.PageSize;
				// Events
				paginator.ComputePageCountCompleted += (s, ev) => this.OnComputePageCountCompleted(ev);
				paginator.GetPageCompleted += (s, ev) => this.OnGetPageCompleted(ev);
				paginator.PagesChanged += (s, ev) => this.OnPagesChanged(ev);
			}
			public override DocumentPage GetPage(int pageNumber)
			{
				DocumentPage cachedPage;
				if (_PageCache.TryGetValue(pageNumber, out cachedPage) && cachedPage.Visual != null) return cachedPage;
				DocumentPage page = _Paginator.GetPage(pageNumber);
				// Create a wrapper visual for transformation and add extras
				ContainerVisual newpage = new ContainerVisual();
				// TODO Transform the wrapped page, add your headers and footers.
				// This is highly idiosyncratic.
				...
				// NB We assume that page.BleedBox has X=0, Y=0, Size=page.PageSize
				cachedPage = new DocumentPageWrapper(page, newpage, PageSize, new Rect(PageSize), new Rect(page.ContentBox.X, page.ContentBox.Y, page.ContentBox.Width + _Margin.Left + _Margin.Right, page.ContentBox.Height + _Margin.Top + _Margin.Bottom));
				_PageCache[pageNumber] = cachedPage;
				return cachedPage;
			}
			public override bool IsPageCountValid { get { return _Paginator.IsPageCountValid; } }
			public override int PageCount { get { return _Paginator.PageCount; } }
			public override Size PageSize
			{
				get { var value = _Paginator.PageSize; return new Size(value.Width + _Margin.Left + _Margin.Right, value.Height + _Margin.Top + _Margin.Bottom); }
				set { _Paginator.PageSize = new Size(value.Width - _Margin.Left - _Margin.Right, value.Height - _Margin.Top - _Margin.Bottom); }
			}
			public override IDocumentPaginatorSource Source { get { return _Paginator.Source; } }
		}
		/// <summary>
		/// It's necessary to dispose the page returned by the wrapped DocumentPaginator when the page we return is disposed,
		/// because otherwise we inconsistently get ArgumentExceptions due to the page.Visual still being in use.
		/// </summary>
		class DocumentPageWrapper : DocumentPage
		{
			internal DocumentPageWrapper(DocumentPage originalPage, Visual visual, Size pageSize, Rect bleedBox, Rect contentBox)
				: base(visual, pageSize, bleedBox, contentBox)
			{
				_OriginalPage = originalPage;
			}
			private DocumentPage _OriginalPage;
			public override void Dispose()
			{
				base.Dispose();
				if (_OriginalPage != null)
				{
					_OriginalPage.Dispose();
					_OriginalPage = null;
				}
			}
		}
