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
	    public Dictionary<Building, Result> ResultsByBuilding;
	    public Dictionary<Improvement, Result> ResultsByImprovement;
	
	    public void CalculateAndAggregate(IEnumerable<Building> buildings, IEnumerable<Improvement> improvements) {
            ResultsByBuilding = new Dictionary<Building, Result>();
            ResultsByImprovement = new Dictionary<Improvement, Result>();
		    for (building in buildings) {
			    for (improvement in improvements) {
				    Result result = DoHeavyCalculation(building, improvement);
				
				    if (ResultsByBuilding.ContainsKey(building)) {
					    ResultsByBuilding[building].Add(result);
				    } else {
					    ResultsByBuilding[building] = result;
				    }
				
				    if (ResultsByImprovement.ContainsKey(improvement)) {
					    ResultsByImprovement[improvement].Add(result);
				    } else {
					    ResultsByImprovement[improvement] = result;
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
