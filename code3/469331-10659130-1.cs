    select new { p1, p2, p3, p4 })
    .AsEnumerable()
    .Select(tr => new EditableWarrantBook
        {
        Id = tr.p1.id,
        Comment = tr.p1.EntryComment,
        WarrantYear = new[] {
            new BookYear
            {
                StatusYear = tr.p2.StatusYear,
                Status = tr.p2.Status,
            },
            new BookYear
            {
                StatusYear = tr.p3.StatusYear,
                Status = tr.p3.Status,
            },
            new BookYear
            {
                StatusYear = tr.p4.StatusYear,
                Status = tr.p4.Status,
            }}
        }).ToList();
    
