    var qr = new QueryRequest
    {
        ItemsElementName = new ItemsChoiceType1[] {
            ItemsChoiceType1.QueryMarketResults,
        },
        Items = new object[] {
            new QueryByAllLocationDayTypeType
            {
                ItemElementName = ItemChoiceType3.All,
                Item = new QueryAllType(),
                day = Convert.ToDateTime("2012-11-16"),
                type = MarketQueryTypeType.Virtual,
            },
        },
    }
