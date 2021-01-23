    if(_db.ManhattanLUSESalesPriceIndex().Count() < 5)
    {
	// throw
    }
    else
    {
        var collectionStore = _db.ManhattanLUSESalesPriceIndex().ToList();
        for(int i = 5; i < collectionStore.Count(); i++)
        {
            var recordN = collectionStore[i-5];
            // do whatever outputting you want
            var recordNPlusFive = collectionStore[i];
            // do whatever outputting you want
            }
        }
    }
