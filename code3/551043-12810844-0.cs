    for (int subjectIndex = 0; subjectIndex < Model.Subjects.Count; subjectIndex++) {
        @Html.TextBoxFor(x => x.Subjects[subjectIndex].Name)
        for (int binIndex = 0; binIndex < Model.Subjects.Bins.Count; binIndex++) {
            @Html.TextBoxFor(x => x.Subjects[subjectIndex].Bins[binIndex].Amount)
        }
    }
