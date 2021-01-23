            string[] keywordArray = new string[] {"A", "B", "C", "D"};
            var products = repository.GetAllProducts();
            IList<Product> tempResult = new List<Product>();
            foreach (var keyword in keywordArray)
            {
                //declared because of access to modified closure issue.
                string keyword1 = keyword;
                tempResult = tempResult.Union(products.Where(p => 
                   p.ProductDesc.Contains(keyword1))).ToList();
            }
