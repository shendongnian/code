	public class CustomRichTextBox<T> : Forms.RichTextBox
		where T : CustomType, new()
	{
		public object GetValue()
		{
			T t = new T();
			t.InnerString = this.Rtf;
			return t;
		}
	}
