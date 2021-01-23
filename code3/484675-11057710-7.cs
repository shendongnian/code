    ...
    format: (item) =>
                                Html.DateTimeActionLink(
                                        //added cast
                                        (Nullable<DateTime>)(item.AssessmentDate),
                                        "MM/dd/yyyy",
                                        //added cast
                                        x => Html.ActionLink((string)(item.AssessmentInfo) + " | " + x, "Edit", "MdsAsmtSectionQuestions", new { mdsId = item.OngoingId }, null));
    ...
