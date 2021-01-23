    class KnownMove {
       public string Column1 {get; set;}
       public string Column2 {get; set;}
       public string Column3 {get; set;}
    }
    List<KnownMove > lstKnownMoves = dsAttacksTemp.Tables[0].Rows
     .Cast<DataRow>()
     .SelectMany(r => new KnownMove{
                        Column1 = r["Column1"].ToString(),
                        Column2 = r["Column2"].ToString(),
                        Column3 = r["Column3"].ToString()})
     .ToList();
