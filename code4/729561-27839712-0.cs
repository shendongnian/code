	public abstract class CustomWebViewPage: WebViewPage
	{
		public override string Layout
		{
			get
			{
				return Request.IsAjaxRequest() || ViewContext.IsChildAction ? null : base.Layout;
			}
			set
			{
				base.Layout = value;
			}
		}
	}
	public abstract class CustomWebViewPage<TModel>: CustomWebViewPage
	{
	}
