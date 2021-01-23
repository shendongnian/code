    using System.Collections.Generic;
    namespace HierarchicalDataTemplateAndTreeView
    {
    	public class Composite
    	{
    		public string Name { get; set; }
    		public List<Composite> Children { get; set; }
    	}
        public class Task: Composite
    	{
    	}
    	public class Person : Composite
    	{
    	}
    	public class ItemCollection : Composite
    	{
    	}
    	public class Item : Composite
    	{
    	}
    	public class DayCollection : Composite
    	{
    	}
    	public class Day : Composite
    	{
    	}
    }
