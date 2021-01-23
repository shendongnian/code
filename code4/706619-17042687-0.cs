    var doc = XDocument.Parse(@"
        <ItemDetails>
            <ItemDetail>
                <Item>
                    <RecommendedRetailPrice>
                        <PriceAmount>4.95</PriceAmount>
                    </RecommendedRetailPrice>
                </Item>
            </ItemDetail>
        </ItemDetails>
    ");
    var result = doc
        .Element("ItemDetails")
        .Elements("ItemDetail")
        .Elements("Item")
        .OrderBy(item =>
            item.Elements("RecommendedRetailPrice")
                .Elements("PriceAmount")
                .Select(pa => Convert.ToDouble(pa.Value,
                                  CultureInfo.InvariantCulture))
                .FirstOrDefault())
        .Last();
    Console.WriteLine(result);
