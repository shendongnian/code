	public class MyDataSource:NSOutlineViewDataSource
	{
	    /// The list of persons (top level)
		public List<Person> Persons {
			get;
			set;
		}
        // Constructor
		public MyDataSource()
		{
		    // Create the Persons list
			Persons = new List<Person>();
		}
		public override int GetChildrenCount (NSOutlineView outlineView, NSObject item)
		{
            // If the item is not null, return the child count of our item
			if(item != null)
				return (item as Person).Children.Count;
            // Its null, that means its asking for our root element count.
			return Persons.Count();
		}
		public override NSObject GetObjectValue (NSOutlineView outlineView, NSTableColumn forTableColumn, NSObject byItem)
		{
            // Is it null? (It really shouldnt be...)
			if (byItem != null) {
			    // Jackpot, typecast to our Person object
				var p = ((Person)byItem);
                // Get the table column identifier
				var ident = forTableColumn.Identifier.ToString();
                // We return the appropriate information for each column
				if (ident == "colName") {
					return (NSString)p.Name;
				}
				if (ident == "colAge") {
					return (NSString)p.Age.ToString();
				}
			}
            // Oh well.. errors dont have to be THAT depressing..
			return (NSString)"Not enough jQuery";
		}
		public override NSObject GetChild (NSOutlineView outlineView, int childIndex, NSObject ofItem)
		{
		    // If the item is null, it's asking for a root element. I had serious trouble figuring this out...
			if(ofItem == null)
				return Persons[childIndex];
            // Return the child its asking for.
			return (NSObject)((ofItem as Person).Children[childIndex]);
		}
		public override bool ItemExpandable (NSOutlineView outlineView, NSObject item)
		{
		    // Straight forward - it wants to know if its expandable.
			if(item == null)
				return false;
			return (item as Person).Children.Count > 0;
		}
	}
