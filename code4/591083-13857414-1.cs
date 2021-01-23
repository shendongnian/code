    var query = db.Subjects.Select(s => new SubjectSelection()
                         {
                            ID = s.ID,
                            Title = s.Title,
                            IsSelected = selectedIDs.Contains(s.ID)
                         });
