    public class Building {
	    public int ID { get; set; }
	    ...
    }
    public class Improvement {
	    public int ID { get; set; }
	    ...
    }
    public class Result {
	    public decimal Foo { get; set; }
	    public long Bar { get; set; }
	    ...
	
	    public void Add(Result result) {
		    Foo += result.Foo;
		    Bar += result.Bar;
		    ...
	    }	
    }
    public class Calculator {
	    public Dictionary<Building, Result> ResultByBuilding = new Dictionary<int, Result>();
	    public Dictionary<Improvement, Result> ResultByImprovement = new Dictionary<int, Result>();
	
	    public void CalculateAndAggregate(IEnumerable<Building> buildings, IEnumerable<Improvement> improvements){
		    for (building in buildings) {
			    for (improvement in improvements) {
				    Result result = DoHeavyCalculation(building, improvement);
				
				    if (ResultByBuilding.ContainsKey(building)) {
					    ResultByBuilding[building].Add(result);
				    } else {
					    ResultByBuilding[building] = result;
				    }
				
				    if (ResultByImprovement.ContainsKey(improvement)) {
					    ResultByImprovement[improvement].Add(result);
				    } else {
					    ResultByImprovement[improvement] = result;
				    }
			    }
		    }
	    }
    }
    public static void Main() {
	    var calculator = new Calculator();
	    IList<Building> buildings = GetBuildingsFromRepository();
	    IList<Improvement> improvements = GetImprovementsFromRepository();
	    calculator.CalculateAndAggregate(buildings, improvements);
	    DoStuffWithResults(calculator);
    }
