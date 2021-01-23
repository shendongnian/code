    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string SubBranchName { get; set; }
        public string ProductName { get; set; }
    }
    public static class MyEnumerableExtensions
    {
        /// <summary>
        /// Applies grouping to the collection of elements using the selectors specified
        /// </summary>
        /// <typeparam name="TElement">Type of the element</typeparam>
        /// <param name="elements">Elements to be grouped</param>
        /// <param name="groupSelectors">Selectors, or properties to be grouped on</param>
        /// <returns></returns>
        public static IEnumerable<GroupResult> GroupByMany<TElement>(
            this IEnumerable<TElement> elements,
            params Func<TElement, object>[] groupSelectors)
        {
            if (groupSelectors.Length > 0)
            {
                var selector = groupSelectors.First();
                //reduce the list recursively until zero
                var nextSelectors = groupSelectors.Skip(1).ToArray();
                return
                    elements.GroupBy(selector).Select(
                        g => new GroupResult
                        {
                            Key = g.Key,
                            Items = g,
                            SubGroups = g.GroupByMany(nextSelectors)
                        });
            }
            return null;
        }
        public class GroupResult
        {
            public object Key { get; set; }
            public IEnumerable Items { get; set; }
            public IEnumerable<GroupResult> SubGroups { get; set; }
        }
    }
       
    //Your usage of the GroupByMany
    IEnumerable<Company> list = new List<Company>
     {new Company{CompanyID = 1, CompanyName = "Company1", ProductName = "Product1", SubBranchName = "SB1"},
     new Company{CompanyID = 2, CompanyName = "Company1", ProductName = "Product2", SubBranchName = "SB2"},
     new Company{CompanyID = 3, CompanyName = "Company1", ProductName = "Product3", SubBranchName = "SB1"},
     new Company{CompanyID = 4, CompanyName = "Company2", ProductName = "Product4", SubBranchName = "SB2"},
     new Company{CompanyID = 5, CompanyName = "Company2", ProductName = "Product1", SubBranchName = "SB2"},
     new Company{CompanyID = 6, CompanyName = "Company2", ProductName = "Product2", SubBranchName = "SB1"},
     new Company{CompanyID = 7, CompanyName = "Company2", ProductName = "Product3", SubBranchName = "SB2"},
     new Company{CompanyID = 8, CompanyName = "Company3", ProductName = "Product4", SubBranchName = "SB2"},
     new Company{CompanyID = 9, CompanyName = "Company3", ProductName = "Product3", SubBranchName = "SB1"},
     new Company{CompanyID = 10, CompanyName = "Company3", ProductName = "Product2", SubBranchName = "SB2"},
     };
        var groupedByProductNameThenSubBranchName = list.GroupByMany(p => p.ProductName, p => p.SubBranchName);
        foreach (var groupResult in groupedByProductNameThenSubBranchName)
        {
            foreach (var result in groupResult.SubGroups)
            {
                foreach (var groupResult1 in result.Items)
                {
                    Company company = groupResult1 as Company;
                    Debug.Print(String.Format("ProductName: {0}, SubBranchName: {1}", company.ProductName, company.SubBranchName));
                }
            }
        }
        var groupedBySubBranchNameThenCompany = list.GroupByMany(p => p.SubBranchName, p => p.CompanyName);
        foreach (var groupResult in groupedBySubBranchNameThenCompany)
        {
            foreach (var result in groupResult.SubGroups)
            {
                foreach (var groupResult1 in result.Items)
                {
                    Company company = groupResult1 as Company;
                    Debug.Print(String.Format("SubBranchName: {0}, CompanyName: {1}", company.SubBranchName, company.CompanyName));
                }
            }
        }
