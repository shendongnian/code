    public bool deleteBrand(string brand)
    {
        bool result = false;
        try
        {
            List<string> existingBrandName = getBrand();
            if (existingBrandName.Contains(brand))
            {
                XDocument productList = load();
                var query = from positions in productList.Descendants("brand")
                            where (string)positions.Attribute("name").Value == brand
                            select positions;
                XElement selectedBrand = query.ElementAt(0);
                selectedBrand.RemoveAll();
                var toCheck = productList.Descendants("stock")
                                         .Concat(productList.Descendants("brand"));
                var emptyElements = from element in toCheck
                                    where element.IsEmpty
                                    select element;
                while (emptyElements.Any())
                    emptyElements.Remove();
                productList.Save(path);
                result = true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        return result;
    }
