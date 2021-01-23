    var project = ProjectRootElement.Open(fileName);
    var referenceElements = project.Items
        .Where(x => x.ItemType.Equals("Reference"))
        .Where(x => x.HasMetadata && x.Metadata.Any(m => m.Name.Equals("HintPath") && CheckLocation(m.Value)));
    
        foreach (var projectItemElement in referenceElements) 
        {
            var copyLocalElement = projectItemElement.Metadata.FirstOrDefault(x => x.Name.Equals("CopyLocal"));
            if (copyLocalElement != null) 
            {
                copyLocalElement.Value = "false";
                continue;
            }
            projectItemElement.AddMetadata("CopyLocal", "false");
        }
