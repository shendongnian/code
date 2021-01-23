        using (var dc = new TestDataContext())
        {
            // Get all the ids of interest.
            // I assume you mark successfully updated rows in some way
            // in the update transaction.
            List<int> ids = dc.TestItems.Where(...).Select(item => item.Id).ToList();
            var problematicIds = new List<ErrorType>();
            // Either allow the TaskParallel library to select what it considers
            // as the optimum degree of parallelism by omitting the 
            // ParallelOptions parameter, or specify what you want.
            Parallel.ForEach(ids, new ParallelOptions {MaxDegreeOfParallelism = 8},
                                id => CalculateDetails(id, problematicIds));
        }
