        if (theFight.VotedID == f1.FighterID)
        {
            theFight.BlueCornerPercent++;
            db.Entry(theFight).Property(p => p.BlueCornerPercent).IsModified = true;
            db.Entry(theFight).Property(p => p.RedCornerPercent).IsModified = false;
            db.SaveChanges();
        }
