    public class Job
    {
    	public List<Doc> Docs;
    }
    
    public class Doc
    {
    	public int Words;
    }
    
    List<Job> Jobs = new List<Job> { 
    	new Job { Docs = new List<Doc> { new Doc { Words = 5 }, new Doc { Words = 10} } }, 
    	new Job { Docs = new List<Doc> { new Doc { Words = 5 } } }
    };
    
    var res = Jobs.Select(x => new { Jobs = x, Cnt = x.Docs.Sum(y => y.Words) });
