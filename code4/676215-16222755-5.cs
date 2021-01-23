    public ActionResult ReorderClues(TreasureHuntDetails treasureHuntDetails, int[] ids)
    {
        using (var db = new TreasureHuntDB())
        {
            var clues = treasureHuntDetails.Clues;
            var newClues = NewOrderList(clues, ids);
            // Save the changes of each clue
            for (var i = 0; i < newClues.Count;i++ )
            {
                db.Entry(clues[i]).CurrentValues.SetValues(newClues[i]);
                db.SaveChanges();
            }
            treasureHuntDetails.Clues = newClues;
            TempData["Success"] = "Clues reordered";
        }
        return RedirectToAction("Clues", treasureHuntDetails);
    }
    public List<Clue> NewOrderList(List<Clue> clues, int[] ids)
    {
        var newClueOrder = new List<Clue>();
        // For each ID in the given order
        for (var i = 0; i < ids.Length; i++)
        {
            // Get the original clue that matches the given ID
            var clue = clues.First(clue1 => clue1.Id == ids[i]);
            var newClue = Clue.Clone(clue);
            // Add the clue to the new list. 
            newClueOrder.Add(newClue);
            // Retain the ID of the clue 
            newClueOrder[i].Id = clues[newClueOrder.Count - 1].Id;
        }
        return newClueOrder;
    }
