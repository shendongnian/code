    public static IQueryable<Card> SelectCards(this IQueryable<Customer> query)
    {
        return query.Select(c => new 
        { 
            Id = c.Id, 
            InfoCard = new Card
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    FullName = c.FirstName + " " + c.LastName
                } 
        });
    }
