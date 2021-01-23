    public class FormattingTag
    {
    	private int start;
    	private int length;
    
    	private FormattingTag(int start, int length)
    	{
    		this.start = start;
    		this.length = length;
    	}
    
    	public int Start
    	{
    		get{ return this.start; }
    	}
    
    	public int Length
    	{
    		get { return this.length; }
    	}
    
    	public TextPointer StartPosition { get; private set; }
    
    	public TextPointer EndPosition { get; private set; }
    
    	public DependencyProperty FormattingProperty { get; private set; }
    
    	public object Value { get; private set; }
    
    	public static FormattingTag GetTag(TextPointer start, int startIndex, int length, DependencyProperty formattingProperty, object value)
    	{
    		while (start.GetPointerContext(LogicalDirection.Forward) != TextPointerContext.Text)
    		{
    			start = start.GetNextContextPosition(LogicalDirection.Forward);
    		}
    
    		TextPointer contentStart = start.GetPositionAtOffset(startIndex);
    		TextPointer contentEnd = contentStart.GetPositionAtOffset(length);
    		FormattingTag tag = new FormattingTag(startIndex, length);
    		tag.StartPosition = contentStart;
    		tag.EndPosition = contentEnd;
    		tag.FormattingProperty = formattingProperty;
    		tag.Value = value;
    		return tag;
    	}
    
    	public void ApplyFormatting()
    	{
    		TextRange range = new TextRange(this.StartPosition, this.EndPosition);
    		range.ApplyPropertyValue(this.FormattingProperty, this.Value);
    	}
    }
