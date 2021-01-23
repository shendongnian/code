    select new EditableWarrantBook
    {
        Id = p1.id,
        Comment = p1.EntryComment,
        WarrantYear = new[] {
            new BookYear
            {
                StatusYear = p2.StatusYear,
                Status = p2.Status,
            },
            new BookYear
            {
                StatusYear = p3.StatusYear,
                Status = p3.Status,
            },
            new BookYear
            {
                StatusYear = p4.StatusYear,
                Status = p4.Status,
            }}
    }
