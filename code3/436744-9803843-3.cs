    using System.Linq;
    // ...
    public void Sort(bool asc, string column)
    {
        if (column == "LastName")
        {
            People = People.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        }
        else
        {
            People = People.OrderBy(x => x.PostCode).ToList();
        }
        if (!asc)
        {
            People.Reverse();
        }
    }
