    public static List<MySlideClass.Slide> DeserializePresentation(string FileName)
    {
    	List<MySlideClass.Slide> returnList = new List<MySlideClass.Slide>();
    
    	using(StreamReader streamReader = new StreamReader(FileName))
    	{
    		XmlSerializer xmlReader = new XmlSerializer(typeof(List<MySlideClass.Slide>));
    		returnList = (List<MySlideClass.Slide>) xmlReader.Deserialize(streamReader);
    	}
    	return returnList;
    }
