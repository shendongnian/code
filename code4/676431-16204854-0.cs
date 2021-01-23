            // Get the original clue that matches the given ID
            var clue = clues.First(clue1 => clue1.Id == ids[i]);
            // Copy constructor
            var newClue = new Clue(clue);
            // Or, use cloning
            var newClue = clue.Clone();
            // Add the clue to the new list. 
            newClueOrder.Add(clue);
            // Retain the ID of the clue 
            newClueOrder[i].Id = clues[newClueOrder.Count - 1].Id;
