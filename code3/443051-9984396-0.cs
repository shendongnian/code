    void Main()
    {
    	var data = new[]
    	{ 
    		new Record { Id = 1, ParentId = null, Qty = 1, Cost = 0.0m },
    		new Record { Id = 2, ParentId = 1, Qty = 2, Cost = 0.0m },
    		new Record { Id = 3, ParentId = 1, Qty = 3, Cost = 0.0m },
    		new Record { Id = 4, ParentId = 2, Qty = 4, Cost = 0.0m },
    		new Record { Id = 5, ParentId = 3, Qty = 5, Cost = 0.0m },
    		new Record { Id = 6, ParentId = 2, Qty = 6, Cost = 1.7m },
    		new Record { Id = 7, ParentId = 4, Qty = 7, Cost = 1.8m },
    		new Record { Id = 8, ParentId = 5, Qty = 8, Cost = 1.9m },
    		new Record { Id = 9, ParentId = 5, Qty = 9, Cost = 2.0m },
    	}.ToList();
    	
    	// Mimic ORM's job:
    	data.ForEach(d => d.ChildRecords = 
    		data.Where(c => c.ParentId == d.Id).ToList());
    	
    	data.Select(d => new { d.Id, d.Cost, d.TotalCost } ).Dump();
    }
    
    class Record
    {
    	public int Id { get; set; }
    	public int? ParentId { get; set; }
    	public int Qty { get; set; }
    	
    	private decimal _cost = 0m;
    	public decimal Cost
    	{
    		get { return this._cost + this.ChildRecords.Sum(cr => cr.TotalCost); }
    		set { this._cost = value; }
    	}
    	
    	public decimal TotalCost
    	{ 
    		get { return this.Qty * this.Cost; }
    	}
    	
    	public ICollection<Record> ChildRecords;
    }
