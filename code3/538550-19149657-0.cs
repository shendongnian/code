	void Main()
	{
		//using Microsoft.Office.Interop.Outlook
		Application oApp = new Application();
		NameSpace oSes = oApp.Session;
		Categories oCats = oSes.DefaultStore.Categories;
		//remove existing categories
		var catids = (from a in oCats.Cast<Category>() select a.CategoryID).ToArray();
		for (int i = 0; i < catids.Count(); i++)
		{
			var cid = catids[i];
			cid.Dump();
			while(oCats[cid] != null)
			{
				oCats.Remove(cid);
				oCats = oSes.DefaultStore.Categories;
				Thread.Sleep(100);
			}
		}
		//dictionary to hold my categories
		Dictionary<string,OlCategoryColor> dCats = new Dictionary<string,OlCategoryColor>();
		dCats.Add("Category One",OlCategoryColor.olCategoryColorRed);
		dCats.Add("Category Two",OlCategoryColor.olCategoryColorOrange);
		dCats.Add("Category Three",OlCategoryColor.olCategoryColorPeach);
		dCats.Add("Category Four",OlCategoryColor.olCategoryColorYellow);
		
		foreach (var dCat in dCats)
		{
			var cid = dCat.Key;
			cid.Dump();
			while(oCats[cid] == null)
			{
				oCats.Add(cid,dCat.Value);
				oCats = oSes.DefaultStore.Categories;
				Thread.Sleep(100);
			}
		}
				
		//show categories
		var cats = from c in oCats.Cast<Category>() select new {
			c.CategoryBorderColor,
			c.CategoryGradientBottomColor,
			c.CategoryGradientTopColor,
			c.CategoryID,
			c.Class,
			c.Color,
			c.Name,
			c.ShortcutKey
		};
		cats.Dump();
			
	}
