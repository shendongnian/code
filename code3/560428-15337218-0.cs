    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using Roslyn.Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace RoslynMsBuildTask
    {
        public class RoslynTask : Task
        {
            [Required]
            public ITaskItem[] ReferencePath { get; set; }
    
            [Required]
            public ITaskItem[] Compile { get; set; }
    
            [Required]
            public ITaskItem BaseDirectory { get; set; }
    
            public override bool Execute()
            {
                Log.LogMessage(MessageImportance.High, "RoslynTask.Execute called...\n");
    
                // Format the command line with the minimal info needed for Roslyn to create a workspace.
                var commandLineForProject = string.Format("/reference:{0} {1}",
                    ReferencePath.Select(i => i.ItemSpec).ToSingleString(",", "\"", "\""),
                    Compile.Select(i => i.ItemSpec).ToSingleString(" ", "\"", "\""));
    
                // Create the Roslyn workspace.
                var workspace = Workspace.LoadProjectFromCommandLineArguments("MyProject", "C#", commandLineForProject, BaseDirectory.ItemSpec);
    
                // Make sure that Roslyn actually parsed the project: dump the source from a syntax tree to the build log.
                Log.LogMessage(MessageImportance.High, workspace.CurrentSolution.Projects.First()
                    .Documents.First(i => i.FilePath.EndsWith(".cs")).GetSyntaxRoot().GetText().ToString());
    
                return true;
            }
        }
    
        public static class IEnumerableExtension
        {
            public static string ToSingleString<T>(this IEnumerable<T> collection, string separator, string leftWrapper, string rightWrapper)
            {
                var stringBuilder = new StringBuilder();
    
                foreach (var item in collection)
                {
                    if (stringBuilder.Length > 0)
                    {
                        if (!string.IsNullOrEmpty(separator))
                            stringBuilder.Append(separator);
                    }
    
                    if (!string.IsNullOrEmpty(leftWrapper))
                        stringBuilder.Append(leftWrapper);
    
                    stringBuilder.Append(item.ToString());
    
                    if (!string.IsNullOrEmpty(rightWrapper))
                        stringBuilder.Append(rightWrapper);
                }
    
                return stringBuilder.ToString();
            }
        }
    }
