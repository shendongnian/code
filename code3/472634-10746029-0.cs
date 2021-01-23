void Main()
{
	var cat1 = new ItemCategoryBO {ItemCategory="c1", Title = "c1"};
	var cat2 = new ItemCategoryBO {ItemCategory="c2", Title = "c2"};
	
	var item1 = new ItemBO { ItemId = 1, Title = "item1", ItemCategory="c1"};
	var item2 = new ItemBO { ItemId = 1, Title = "item2", ItemCategory="c2"};
	var item3 = new ItemBO { ItemId = 1, Title = "item3", ItemCategory="c2"};
	var item4 = new ItemBO { ItemId = 1, Title = "item4", ItemCategory="c3"};
	
	var items = new List<ItemBO>() {item1, item2, item3, item4};
	var categories = new List<ItemCategoryBO>() {cat1, cat2};
	
	var itemsInCategory = from item in items 
	join category in categories on  item.ItemCategory equals category.ItemCategory into itemInCategory
	from categoryItem in itemInCategory
	select new {item.Title, item.ItemCategory};
	
	itemsInCategory.Dump();	
}
// Define other methods and classes here
	  public class ItemCategoryBO
		{
		   public string ItemCategory { get; set; }
		   public string Title { get; set; }
		}
	
		public class ItemBO
		{
		   public int ItemId { get; set; }
		   public string Title { get; set; }
		   public string ItemCategory { get; set; } 
		}
