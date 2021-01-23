    public class Document
    {
        public virtual string DocumentName {get; set;}
        
        public EDocumentName Name 
        {
            get 
			{
				if (DocumentName == "Title Holder")
				{
					return EDocumentName.TitleHolder;
				}
			}
			set
			{
				if(value == EDocumentName.TitleHolder)
				{
					DocumentName = "Title Holder";
				}
			}
		}
	}
	
	public enum EDocumentName
	{
		TitleHoldder
	}
        
