    <#@ template hostspecific="true" #>
    <#@ import namespace="System" #>
    <#@ import namespace="System.IO" #>
    namespace ClassLibrary1
    {
        public class Version
        {
            <#  var project = new FileInfo(Host.ResolvePath("ClassLibrary1.csproj"));
                WriteLine("// " + project.FullName);
                
                var files = project.Directory.GetFileSystemInfos("*.cs", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    var name = Path.GetFileNameWithoutExtension(file.Name);
                    if (name == "Version")
                        continue; #>
                   public const long <#= name #> = <#= file.LastWriteTime.Ticks #>;
            <#  } #>
        }
    }
