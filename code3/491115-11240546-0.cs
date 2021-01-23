    public List<GetChild1> FilterExample()
    {
        IQueryable<GetChild1> result = _context.GetChild1;
        result = from p in result
                 where p.UploadDate < startDate;
                 select p;
        //until this moment the query is still not send to the database.
        result = result.OrderBy(p => p.UploadDate);
        //when you call the ToList method the query will be executed on the database and the list of filtered and sorted items will be returned. Notice the sorting and filtering is done in the database which is faster than doing it in memory
        List<GetChild1> populatedResult = result.ToList();
        return populatedResult;
    }
