	/// <summary>
	/// Makes all text after a colon (until the end of line) upper-case.
	/// </summary>
	public class UppercaseGenerator : VisualLineElementGenerator
	{
		public override int GetFirstInterestedOffset(int startOffset)
		{
			TextDocument document = CurrentContext.Document;
			int endOffset = CurrentContext.VisualLine.LastDocumentLine.EndOffset;
			for (int i = startOffset; i < endOffset; i++) {
				char c = document.GetCharAt(i);
				if (c == ':')
					return i + 1;
			}
			return -1;
		}
		
		public override VisualLineElement ConstructElement(int offset)
		{
			DocumentLine line = CurrentContext.Document.GetLineByOffset(offset);
			return new UppercaseText(CurrentContext.VisualLine, line.EndOffset - offset);
		}
		
		/// <summary>
		/// Displays a portion of the document text, but upper-cased.
		/// </summary>
		class UppercaseText : VisualLineText
		{
			public UppercaseText(VisualLine parentVisualLine, int length) : base(parentVisualLine, length)
			{
			}
			
			protected override VisualLineText CreateInstance(int length)
			{
				return new UppercaseText(ParentVisualLine, length);
			}
			
			public override TextRun CreateTextRun(int startVisualColumn, ITextRunConstructionContext context)
			{
				if (context == null)
					throw new ArgumentNullException("context");
				
				int relativeOffset = startVisualColumn - VisualColumn;
				StringSegment text = context.GetText(context.VisualLine.FirstDocumentLine.Offset + RelativeTextOffset + relativeOffset, DocumentLength - relativeOffset);
				char[] uppercase = new char[text.Count];
				for (int i = 0; i < text.Count; i++) {
					uppercase[i] = char.ToUpper(text.Text[text.Offset + i]);
				}
				return new TextCharacters(uppercase, 0, uppercase.Length, this.TextRunProperties);
			}
		}
	}
