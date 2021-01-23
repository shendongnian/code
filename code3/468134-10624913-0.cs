    StringBuilder builder = new StringBuilder();
    foreach (EA.Element element in elementsCol)
    {
        if ((element.Type == "Class") || (element.Type == "Component") || (element.Type == "Package"))
        {
            builder.AppendLine(element.ToString());
        }
     }
     Console.WriteLine("The nodes of MDG are:" + builder.ToString());
