    var docProp = project.EnvironmentalAssessment
                .GetType()
                .GetProperty(techStudy.DocumentProperty);
     docProp.PropertyType.GetProperty("Review")
                .SetValue(docProp.GetValue(project.EnvironmentalAssessment), _review, null);
