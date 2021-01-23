    if(_db.ManhattanLUSESalesPriceIndex().Count() < 5)
    {
	// throw
    }
    else
    {
        for(int i = 5; i < _db.ManhattanLUSESalesPriceIndex().Count(); i++)
        {
            var recordN = _db.ManhattanLUSESalesPriceIndex().Get(i-5);
            // do whatever outputting you want
            var recordNPlusFive = _db.ManhattanLUSESalesPriceIndex().Get(i);
            // do whatever outputting you want
            }
        }
    }
