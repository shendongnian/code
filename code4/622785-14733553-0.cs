    var possiblyNullProblemCode= 
        averages.Where(
            x => x.ProblemCode == opencall.ProblemCode)
            .SingleOrDefault();
    openCall.Priority = 
        possiblyNullProblemCode == null ? 
            string.Empty : 
            possiblyNullProblemCode.Priority;
