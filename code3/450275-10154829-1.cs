    [HttpPost]
    public ActionResult Create(tblGame tblgame, // tblGame is the new game being created
           HttpPostedFileBase image1,
           HttpPostedFileBase image2)
    {
        try
        {
            if (ModelState.IsValid)
            {
                 /* Go to DB and check if there's a Game already there that matches this
                    one just being added. What's the property you want to check against?
                    That's something you must provide. I just wrote GameName to show you
                    how to do this... */
                 var game = db.tblGames.Single(g => g.GameName == tblGame.GameName);
                 
                 /* OK, can proceed adding this game... since there's no game in the DB
                    that matches this one being added. */
                 if (game == null)
                 {
                    // Continue saving the new game
                 }
                 else /* Abort and display a message to user informing that there's a game
                      already. */
                 {
                    // TODO
                 }
            }
        }
    }
