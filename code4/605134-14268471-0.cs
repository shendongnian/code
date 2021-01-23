    class NumberLetter
    {
    	public string Number {get; set;}
    	public string Letter {get; set;}
    	
    	NumberLetter(string number, string letter)
    	{
    		Number = number;
    		Letter = letter;
    	}
    }
    
    public class AB : MonoBehaviour {
    
        void Start () {
    	
    		
    		
    		List<NumberLetter> myList = new List<NumberLetter>();
    		myList.Add(new NumberLetter("2", "a"));
    		myList.Add(new NumberLetter("2", "b"));
    		myList.Add(new NumberLetter("2", "c"));
    		// ...
    		// writing
    		sing (var sw = new StreamWriter("D:\\new.xml"))
    		{
    			var g = new XmlSerializer(typeof(List<NumberLetter>));
    			g.Serialize(sw, myList);
    		}
    		
    		// reading
            using (var sr = new StreamReader("D:\\new.xml"))
    		{
    			var l = new XmlSerializer(typeof(List<NumberLetter>));
    			myList = (List<NumberLetter>)l.Deserialize(sr);
    		}
    		
    		// ...
        }
    }
