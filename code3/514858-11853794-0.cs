	class RichTextBoxEx : RichTextBox
	{
		protected override void OnSelectionChanged(EventArgs e)
		{
			if (this.SelectionStart != 0)
			{
				this.SelectionStart = 0;
				this.SelectionLength = 0;
			}
			base.OnSelectionChanged(e);
		}
	}
