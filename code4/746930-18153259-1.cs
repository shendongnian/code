    DateTime startTime = DateTime.Now;
    pgDataContext pl = new pgDataContext();
    pl.GetGamesWithPlayer(hdr.qText,hdr.qColumn,GlobalVar.sortColumn,GlobalVar.sortOrder, GlobalVar.pageSize, pgIndex);
    GameList.DataSource = pl.pgnGames;
    GameList.DataBind();
    recordCount = pl.pgnGames.Count();
    GameList.VirtualItemCount = recordCount;
    DateTime endTime = DateTime.Now;
    TimeSpan span = endTime.Subtract(startTime);
