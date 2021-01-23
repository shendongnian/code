    var newItemInBoard = new ItemInBoard
    {
        ItemId = model.ItemId,
        BoardId = model.BoardId,
        CreatedOnDate = DateTime.Now
    };
    con.ItemsInBoard.Add(newItemInBoard);
    con.SaveChanges();
