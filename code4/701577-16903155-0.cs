	public static void Main()
	{
		string inputStream = "whatever.pdf";
		
		PdfReader reader = new PdfReader(inputStream);
	
		var parser = new PdfReaderContentParser(reader);
		var imgScan = new FormListener();
	
		for (int i=1; i<=reader.NumberOfPages; ++i)
			parser.ProcessContent(1, imgScan);
	
		reader.Close();
	
		foreach (var r in imgScan.CheckBoxBoxes)
		{
			r.Dump();
		}
	}
	
	public class CheckboxBox
	{
		public CheckboxBox()
		{
			this.CheckboxStates = new List<bool>();
		}
		
		public string Name { get;set; }
		public List<bool> CheckboxStates {get;set;}
	}
	
	public class FormListener : IRenderListener
	{
		public List<CheckboxBox> CheckBoxBoxes { get;set;}
		private CheckboxBox m_CurrentCheckboxBox { get;set;}
		public FormListener()
		{
			this.CheckBoxBoxes = new List<CheckboxBox>();
			this.BeginNewBox();
		}
		
		public void BeginTextBlock()  {}
		public void EndTextBlock() {}
	
		private void BeginNewBox()
		{
			this.m_CurrentCheckboxBox = new CheckboxBox();
			this.CheckBoxBoxes.Add(this.m_CurrentCheckboxBox);
		}
		
		private bool IsNewBoxStarting(TextRenderInfo renderInfo)
		{
			return Regex.IsMatch(renderInfo.GetText(), @"\d+\.");
		}
		
		public void RenderText(TextRenderInfo renderInfo) { 
			if (this.IsNewBoxStarting(renderInfo))
				BeginNewBox();
			
			this.m_CurrentCheckboxBox.Name += renderInfo.GetText() + " ";
		}
		
		private bool GetCheckboxState(ImageRenderInfo renderInfo)
		{
			var n = renderInfo.GetRef().Number;
			return n == 21; // MagicNumberOfYesCheckboxImage;
		}
		
		public void RenderImage(ImageRenderInfo renderInfo)
		{
			this.m_CurrentCheckboxBox.CheckboxStates.Add(this.GetCheckboxState(renderInfo));
		}
	}
