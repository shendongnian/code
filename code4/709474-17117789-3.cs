    public class Inspections{
    	public int InspectionId {get;set;}
    	public string RestaurantName {get;set;}
    	public DateTime InspectionDate {get;set;}
    }
    void Main()
    {
        var result=GetLatestInspectionDatesForAllRestaurants(2);
    	result.Dump();
    }
    public IQueryable<Inspections> 
        GetLatestInspectionDatesForAllRestaurants(int numRecords) {
    		var i = new[]{
    		new Inspections{InspectionId=1,RestaurantName="Mom&Pop",InspectionDate=DateTime.Parse("10/10/12")},
    		new Inspections{InspectionId=2,RestaurantName="SandwichesPlace",InspectionDate=DateTime.Parse("10/10/12")},
    		new Inspections{InspectionId=3,RestaurantName="Mom&Pop",InspectionDate=DateTime.Parse("10/10/11")},
    		new Inspections{InspectionId=4,RestaurantName="SandwichesPlace",InspectionDate=DateTime.Parse("10/10/11")},
    		new Inspections{InspectionId=5,RestaurantName="Mom&Pop",InspectionDate=DateTime.Parse("10/10/10")},
    		new Inspections{InspectionId=6,RestaurantName="SandwichesPlace",InspectionDate=DateTime.Parse("10/10/10")},
    		new Inspections{InspectionId=7,RestaurantName="BurgerPlace",InspectionDate=DateTime.Parse("10/10/11")},
    		new Inspections{InspectionId=8,RestaurantName="BurgerPlace",InspectionDate=DateTime.Parse("10/10/09")},
    		new Inspections{InspectionId=9,RestaurantName="BurgerPlace",InspectionDate=DateTime.Parse("10/10/08")}
    	};
    	var result=i.GroupBy(g=>g.RestaurantName).SelectMany(g=>g.OrderByDescending(d=>d.InspectionDate).Take(2));
    	return result.AsQueryable();
    	}
