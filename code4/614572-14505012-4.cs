    foreach( var failedGrade in Grade.GradeRows
                                      .Select( x => new String[]{ row.Remark1, row.Remark2, row.Remark3 } )
                                      .Where( remarks => remarks.Intersect( okRemarks ).Count() < remarks.Length ) )
    {
        FailedCourseCodes.Add(failedGrade.CourseCode);
    }
