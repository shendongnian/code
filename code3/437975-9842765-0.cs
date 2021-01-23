    public class MyTextBox : System.Windows.Forms.RichTextBox, Microsoft.Office.Interop.Outlook._DocSiteControl
	{
		private sbyte _suppressAttachements;
		private sbyte _readOnly;
		public sbyte ReadOnly
		{
			get { return _readOnly; }
			set { _readOnly = value; }
		}
		public sbyte SuppressAttachments
		{
			get { return _suppressAttachements; }
			set { _suppressAttachements = value; }
		}
	}
