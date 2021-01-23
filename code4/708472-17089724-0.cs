    public static void UpdateGamesCatRank(List<Tuple<int,int>> updateData)
    {
        using(var db = new ArcadeContext())
        {  
            foreach( var t in updateData )
            {
                db.ExecuteCommand("UPDATE ArcadeGame SET CategoryRank = " + t.Item1 + " WHERE ID = " + Item2);
            }
        }
    }
