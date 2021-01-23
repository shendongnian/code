    string solutionFolder = @"C:\Projects\WpfApplication10\WpfApplication10";
    string CSName = "Goodday.cs";
    string newCSName = "BadDay.cs";
    string projectFile = "WpfApplication10.csproj";
    File.Move(System.IO.Path.Combine(solutionFolder, CSName), System.IO.Path.Combine(solutionFolder, newCSName));
    File.WriteAllText(System.IO.Path.Combine(solutionFolder, projectFile),File.ReadAllText(System.IO.Path.Combine(solutionFolder, projectFile)).Replace(CSName,newCSName));
