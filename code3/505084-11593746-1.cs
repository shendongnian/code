	public class WrapAtCol20 : VisualLineElementGenerator
	{
		public override int GetFirstInterestedOffset(int startOffset)
		{
			DocumentLine line = CurrentContext.Document.GetLineByOffset(startOffset);
			int col = startOffset - line.Offset;
			int wrapCol = ((col / 20) + 1) * 20;
			if (wrapCol < line.Length) {
				return line.Offset + wrapCol;
			}
			return -1;
		}
		
		public override VisualLineElement ConstructElement(int offset)
		{
			return new WrapElement();
		}
		
		class WrapElement : VisualLineElement
		{
			public WrapElement() :  base(visualLength: 1, documentLength: 0)
			{
			}
			
			public override TextRun CreateTextRun(int startVisualColumn, ITextRunConstructionContext context)
			{
				return new TextEndOfLine(1);
			}
		}
	}
