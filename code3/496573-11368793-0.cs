    (from SurveyProgramModel in surveyProgramRepository.Get()
     where SurveyProgramModel.ProgramYear == ProgramYear
     group SurveyProgramModel by SurveyProgramModel.ProgramTypeId)
    .Distinct()
    .Select(programTypeGroup => new ProgramTypeViewModel()
        {
            ProgramTypeIds = programTypeGroup.Key,
            ProgramIds = programTypeGroup.Select(r => r.ProgramId),
            ProgramYears = programTypeGroup.Select(r => r.ProgramYear),
            ProgramTitles = programTypeGroup.Select(r => r.ProgramTitle),
            ProgramTypes = programTypeGroup.Select(r => r.ProgramType.ProgramType).Distinct(),
        };
