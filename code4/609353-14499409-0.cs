        var faresHistoryRepository = Fixture.Freeze<Mock<IRepository<DAL.FareHistory>>>();
    
        var fareHistoryResults = new Queue<List<FareHistory>>();
    
        var fareHistories = new List<DAL.FareHistory>();
        FareHistory fh1 = new FareHistory { FareHistoryId = fareHistoryId + 1, FareId = fareId, ObservationTS = date.AddDays(-1), StatusId = (int)DAL.Enum.Status.Active };
        fareHistories.Add(fh1);
        fh1 = new FareHistory { FareHistoryId = fareHistoryId + 4, FareId = fareId, ObservationTS = date.AddDays(-4), StatusId = (int)DAL.Enum.Status.Active };
        fareHistories.Add(fh1);
        fh1 = new FareHistory { FareHistoryId = fareHistoryId + 5, FareId = fareId, ObservationTS = date.AddDays(-5), StatusId = (int)DAL.Enum.Status.Active };
        fareHistories.Add(fh1);
        fareHistoryResults.Enqueue(fareHistories); // fare histories
    
        var fareHistoriesSample = new List<DAL.FareHistory>();
        fh1 = new FareHistory { FareHistoryId = fareHistoryId + 6, FareId = oldFareId,
     ObservationTS = depDate.AddDays(-fullDaysDifference), StatusId = (int)DAL.Enum.Status.Active };
        fareHistoriesSample.Add(fh1);
            fh1 = new FareHistory { FareHistoryId = fareHistoryId + 7, FareId = oldFareId,
         ObservationTS = depDate.AddDays(-15), StatusId = (int)DAL.Enum.Status.Active };
            fareHistoriesSample.Add(fh1);
            fh1 = new FareHistory { FareHistoryId = fareHistoryId + 8, FareId = oldFareId,
         ObservationTS = depDate.AddDays(-16), StatusId = (int)DAL.Enum.Status.Active };
                        fareHistoriesSample.Add(fh1);
        
            fareHistoryResults.Enqueue(fareHistoriesSample); // fareHistoriesSample
        
            faresHistoryRepository.Setup(
                                fhr => fhr.Find(It.IsAny<ISpecification<FareHistory>>
        ())).Returns(()=>fareHistoryResults.Dequeue());
