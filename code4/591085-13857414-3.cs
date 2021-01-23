    var query = subjects.Select(s => new SubjectSelection()
                         {
                            ID = s.ID,
                            Title = s.Title,
                            IsSelected = semesterSubjects.Contains(s)
                         });
