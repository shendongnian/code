    var candidates = queryCandidates.ToList();
    var elementsToRemove = new List<int>();
    foreach (var row in candidates)
    {
        // ...
        xString = candidates[i].District;
        // ...
        if (temp == false)
        {             
            // ... 
            elementsToRemove.Add(i);
        }  
    }
    for(int i = elementsToRemove.Count - 1; i >= 0; --i)
        candidates.RemoveAt(elementsToRemove[i]);
    return View(candidates);
