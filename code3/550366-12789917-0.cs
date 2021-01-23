    public ViewResult Results(int? programId, int? programYear, int? programTypeId, string toDate, string fromDate, int[] programTypeIdList, int[] programIdList)
    {
        return surveyResponseRepository.Get()
            .Where(x => programIdList == NULL 
                        || programIdList.Contains(x.ProgramId));
    }
