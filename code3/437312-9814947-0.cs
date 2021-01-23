void Main()
{
	var things = new Thing [] {
		new Thing { Value = 100 },
		new Thing { Value = 22 },
		new Thing { Value = 10 },
		new Thing { Value = 303 },
		new Thing { Value = 223}
	};
	
	var query1 = (from t in things
				orderby GetGoodness(t) descending 
				select t).First();
		
	
	var query2 = things.Aggregate((curMax, x) => 
        (curMax == null || (GetGoodness(x) > GetGoodness(curMax)) ? x : curMax));
	
	
}
int GetGoodness(Thing thing)
{
	return thing.Value * 2;
}
public class Thing 
{
	public int Value {get; set;}
}
