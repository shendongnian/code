    var projection = db1.ProjectDetails.Select(t => new ProjectDetailsViewModel
                {
                    Prop1 = t.Prop1,
                    Prop2 = t.Prop2
                });
