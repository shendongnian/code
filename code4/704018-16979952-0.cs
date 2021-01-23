    public class CustomRichTextBox : RichTextBox
    {
    	private readonly List<FormattingTag> formattingTags = new List<FormattingTag>();
    
    	public IEnumerable<FormattingTag> FormattingTags
    	{
    		get { return this.formattingTags; }
    	}
    
    	public void ApplyPropertyValue(int startIndex, int length, DependencyProperty formattingProperty, object value)
    	{
    		TextRange documentRange = new TextRange(this.Document.ContentStart, this.Document.ContentEnd);
    		documentRange.ClearAllProperties();
    		string documentText = documentRange.Text;
    		if (startIndex < 0 || (startIndex + length) > documentText.Length)
    		{
    			return;
    		}
    
    		this.CaretPosition = this.Document.ContentStart;
    		this.formattingTags.Add(FormattingTag.GetTag(this.Document.ContentStart, startIndex, length, formattingProperty, value));
    
    		foreach (var formattingTag in formattingTags)
    		{
    			formattingTag.ApplyFormatting();
    		}
    	}
    }
