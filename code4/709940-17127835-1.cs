    string description = textBox1.Text;
    string descriptionAsCsharpStringLiteral =
        "@\"" + description.Replace("\"", "\"\"") + "\"";
    string attribute =
        "[assembly: AssemblyDescription(" + descriptionAsCsharpStringLiteral + ")]";
    Temp.AppendLine("using System.Reflection;")
        .AppendLine(attribute)
        .AppendLine("namespace ...");
