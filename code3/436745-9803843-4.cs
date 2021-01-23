    using System.Linq;
    // ...
    public void Sort(bool asc, string column)
    {
        switch (column)
        {
            case "LastName":
                People = People.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
            case "PostCode":
                People = People.OrderBy(x => x.PostCode).ToList();
            default:
                // error handling
        }
        if (!asc)
        {
            People.Reverse();
        }
    }
