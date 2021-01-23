		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		namespace LinqToView
		{
			class Program
			{
				static void Main(string[] args)
				{
					using (var context = new NWEntities())
					{
						ViewQuery(context).Where(vw => vw.Product == "Foo").ToList();
					}
				}
				private static IQueryable<vwProducts_by_Categories> ViewQuery(NWEntities context)
				{
					return
						from p in context.Products
						join c in context.Categories on p.CategoryID equals c.CategoryID
						select new vwProducts_by_Categories { Product = p.ProductName, Category = c.CategoryName };
				}
			}
			public class vwProducts_by_Categories
			{
				public string Product { get; set; }
				public string Category { get; set; }
			}
		}
