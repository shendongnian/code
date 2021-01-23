	public class XmlResult : ActionResult
	{
        public XmlDocument Document { private get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            //Do something
        }
	    public bool Equals(XmlResult other)
	    {
	        if(ReferenceEquals(null, other))
	        {
	            return false;
	        }
	        if(ReferenceEquals(this, other))
	        {
	            return true;
	        }
	        return Equals(other.Document, Document);
	    }
	    public override int GetHashCode()
	    {
	        return (Document != null ? Document.GetHashCode() : 0);
	    }
	}
