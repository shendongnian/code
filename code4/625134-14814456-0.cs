    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using NDepend;
    using NDepend.Analysis;
    using NDepend.CodeModel;
    using NDepend.Path;
    using NDepend.Project;
    
    
    class FoldersDiff {
    
       private static readonly NDependServicesProvider s_NDependServicesProvider = new NDependServicesProvider();
          
       internal static void Main() {
          var dirOld = @"C:\MyProduct\OldAssembliesDir".ToAbsoluteDirectoryPath();
          var dirNew = @"C:\MyProduct\NewAssembliesDir".ToAbsoluteDirectoryPath();
    
          Console.WriteLine("Analyzing assemblies in " + dirOld.ToString());
          var codeBaseOld = GetCodeBaseFromAsmInDir(dirOld, TemporaryProjectMode.TemporaryOlder);
          Console.WriteLine("Analyzing assemblies in " + dirNew.ToString());
          var codeBaseNew = GetCodeBaseFromAsmInDir(dirNew, TemporaryProjectMode.TemporaryNewer);
    
          var compareContext = codeBaseNew.CreateCompareContextWithOlder(codeBaseOld);
    
          // So much more can be done by exploring fine-grained diff in codeBases and compareContext
          Dump("Added assemblies", codeBaseNew.Assemblies.Where(compareContext.WasAdded));
          Dump("Removed assemblies", codeBaseOld.Assemblies.Where(compareContext.WasRemoved));
          Dump("Assemblies with modified code", codeBaseNew.Assemblies.Where(compareContext.CodeWasChanged));
          Console.Read();
       }
    
       internal static ICodeBase GetCodeBaseFromAsmInDir(IAbsoluteDirectoryPath dir, TemporaryProjectMode temporaryProjectMode) {
          Debug.Assert(dir.Exists);
          var dotNetManager = s_NDependServicesProvider.DotNetManager;
          var assembliesPath = dir.ChildrenFilesPath.Where(dotNetManager.IsAssembly).ToArray();
          Debug.Assert(assembliesPath.Length > 0); // Make sure we found assemblies
          var projectManager = s_NDependServicesProvider.ProjectManager;
          IProject project = projectManager.CreateTemporaryProject(assembliesPath, temporaryProjectMode);
    
          // In PowerTool context, better call:
          // var analysisResult = ProjectAnalysisUtils.RunAnalysisShowProgressOnConsole(project);
          var analysisResult = project.RunAnalysis();
          return analysisResult.CodeBase;
       }
    
       internal static void Dump(string title, IEnumerable<IAssembly> assemblies) {
          Debug.Assert(!string.IsNullOrEmpty(title));
          Debug.Assert(assemblies != null);
          Console.WriteLine(title);
          foreach (var @assembly in assemblies) {
             Console.WriteLine("   " + @assembly.Name);
          }
       }
    }
