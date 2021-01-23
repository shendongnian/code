    void Main()
    {
    	var processBases = new List<ProcessBase>();
    	var inspectorArticles = new List<InspectorArticle>();
    	var inspectorSamples = new List<InspectorSample>();
    	processBases.Add(new ProcessBase { ID = 1 });
    	processBases.Add(new ProcessBase { ID = 2 });
    	inspectorArticles.Add(new InspectorArticle { ID = 3, ProcessBaseID = 1 });
    	inspectorArticles.Add(new InspectorArticle { ID = 4, ProcessBaseID = 1 });
    	inspectorArticles.Add(new InspectorArticle { ID = 5, ProcessBaseID = 2 });
    	inspectorSamples.Add(new InspectorSample { ID = 6, InspectorArticleID = 3 });
    	inspectorSamples.Add(new InspectorSample { ID = 7, InspectorArticleID = 3 });
    	inspectorSamples.Add(new InspectorSample { ID = 8, InspectorArticleID = 3 });
    	inspectorSamples.Add(new InspectorSample { ID = 9, InspectorArticleID = 4 });
    	inspectorSamples.Add(new InspectorSample { ID = 10, InspectorArticleID = 5 });
    	inspectorSamples.Add(new InspectorSample { ID = 11, InspectorArticleID = 5 });
    	
    	var processBaseID = 1;
    	var results = 	from obj1 in processBases
    					join obj2 in inspectorArticles on obj1.ID equals obj2.ProcessBaseID
    					join obj3 in inspectorSamples on obj2.ID equals obj3.InspectorArticleID
    					where obj1.ID == processBaseID
    					select new { obj1, obj2, obj3 };
    	Console.WriteLine(results);
    }
    
    public class ProcessBase
    {
    	public int ID { get; set; }
    }
    
    public class InspectorArticle
    {
    	public int ID { get; set; }
    	public int ProcessBaseID { get; set; }
    }
    
    public class InspectorSample
    {
    	public int ID { get; set; }
    	public int InspectorArticleID { get; set; }
    }
