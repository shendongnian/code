     void Main()
    {
    	var data = new List<Entry> {
    		new Entry { Group = "A", Date = DateTime.Parse("2012-03-01"), Qty = 5 },
    		new Entry { Group = "A", Date = DateTime.Parse("2012-02-01"), Qty = 1 },
    		new Entry { Group = "A", Date = DateTime.Parse("2012-02-01"), Qty = 3 },
    		new Entry { Group = "B", Date = DateTime.Parse("2012-02-01"), Qty = 4 },
    		new Entry { Group = "A", Date = DateTime.Parse("2012-01-01"), Qty = 1 }
    	};
    	data.GroupBy(d => new { d.Group, d.Date }).Dump();
    }
    
    class Entry
    {
    	public string Group { get; set; }
    	public DateTime Date { get; set; }
    	public int Qty { get; set; }
    }
    
    // Define other methods and classes here
    class Button
    {
    	public Color BackColor
    	{ get; set;}
    }
