	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using Roslyn.Services;
	using Roslyn.Scripting.CSharp;
	
	namespace RoslynSample
	{
	class Program
	{
		static void Main(string[] args)
		{
		RefactorSolution(@"C:\Src\MyApp.Full.sln", "ExternalClient", "ExternalCustomer");
	
		Console.ReadKey();
		}
	
		private static void RefactorSolution(string solutionPath, string fileNameFilter, string replacement)
		{
		var builder = new StringBuilder();
		var workspace = Workspace.LoadSolution(solutionPath);
	
		var solution = workspace.CurrentSolution;
	
		if (solution != null)
		{
			foreach (var project in solution.Projects)
			{
			var documentsToProcess = project.Documents.Where(d => d.DisplayName.Contains(fileNameFilter));
	
			foreach (var document in documentsToProcess)
			{
				var targetItemSpec = Path.Combine(
				Path.GetDirectoryName(document.Id.FileName),
				document.DisplayName.Replace(fileNameFilter, replacement));
	
				builder.AppendFormat(@"tf.exe rename ""{0}"" ""{1}""{2}", document.Id.FileName, targetItemSpec, Environment.NewLine);
			}
			}
		}
	
		File.WriteAllText("rename.cmd", builder.ToString());
		}
	}
	}
