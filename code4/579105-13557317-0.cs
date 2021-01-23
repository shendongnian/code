    void Main()     
    {
                
        var marketReadings = new []
                		{
            			new MarketDataPoint() { Stock = "MSFT", Value = 30.0, Timestamp = DateTime.Parse("11/19/2012 4:10:00 PM") },
            			new MarketDataPoint() { Stock = "MSFT", Value = 30.1, Timestamp = DateTime.Parse("11/19/2012 4:11:00 PM") },
            			new MarketDataPoint() { Stock = "GOOG", Value = 667.97, Timestamp = DateTime.Parse("11/19/2012 4:12:00 PM") },
            			new MarketDataPoint() { Stock = "GOOG", Value = 667.51, Timestamp = DateTime.Parse("11/19/2012 4:12:00 PM") },
            		};
            
            	var stockStream = marketReadings.ToPointStream(Application, e=> PointEvent.CreateInsert(e.Timestamp,e),AdvanceTimeSettings.IncreasingStartTime);  
            			
            	var patternResult = from w in stockStream.Where(x => x.Stock == "MSFT")
            											.AlterEventDuration(e => TimeSpan.FromMinutes(1))
            											.SnapshotWindow(SnapshotWindowOutputPolicy.Clip)
            										select new  {Price = w.Max(e => e.Value)}	;
            
            	patternResult.Dump();	
            }
            
            
            public class MarketDataPoint
            {
            	public string Stock { get; set; }
            	public double Value { get; set; }
            	public DateTime Timestamp { get;set;}
            	
            }
    
    }
