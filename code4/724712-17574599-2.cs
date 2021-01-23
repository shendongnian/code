    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
                var cats = new List<PerformanceCounterCategory>(PerformanceCounterCategory.GetCategories());
                foreach (var name in cats.OrderBy(x => x.CategoryName)) {
                    Console.WriteLine("en-US: " + name.CategoryName);
                }
    
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("nl-NL");
                cats = new List<PerformanceCounterCategory>(PerformanceCounterCategory.GetCategories());
                foreach (var name in cats.OrderBy(x => x.CategoryName)) {
                    Console.WriteLine("nl-NL: " + name.CategoryName);
                }
