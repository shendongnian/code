    var q = (from c in this.Session.Query<Customer>()
             select new { Id = c.Id, InfoCard = c.GetCard() }).Decompile();
        
    [Decompile]
    public static string GetCard(this Customer @this)
    {
        return new Card
            {
                FirstName = @this.FirstName,
                LastName = @this.LastName,
                FullName = @this.FirstName + " " + @this.LastName
            };
    }
