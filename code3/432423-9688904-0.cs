    IEnumerable<TemplateModel> templates =
        from dataTemplate in xDocument.Descendants("dataTemplateSpecification")
        select new TemplateModel
        {
            TemplateModel = 
                (from template in dataTemplate.Element("templates").Elements("template")
                let elements = template.Element("elements").Elements("element")
                select new PatientClass
                {
                    PatientId = (int)elements.Single(e => (string)e.Attribute["name"] == "PatientId").Attribute("value"), 
                    EMPIID = (int)elements.Single(e = (string)e.Attribute["name"] == "EMPIID").Attribute("value"),
                }).ToList()
        };
