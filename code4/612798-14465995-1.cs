    <UsingTask TaskName="Version" TaskFactory="CodeTaskFactory" AssemblyFile="$(MSBuildToolsPath)\Microsoft.Build.Tasks.v4.0.dll">
      <ParameterGroup>
        <Files ParameterType="Microsoft.Build.Framework.ITaskItem[]" Required="true" />
      </ParameterGroup>
      <Task>
        <Using Namespace="System.IO" />
        <Using Namespace="System.Text.RegularExpressions" />
        <Code Type="Fragment" Language="cs"><![CDATA[
              var regex = new Regex(@"Version = (\d+);//(-?\d+)");
              foreach (var file in Files)
              {
                  var source = File.ReadAllText(file.ItemSpec);
                  var match = regex.Match(source);
                  if (!match.Success) continue;
                  var hash = regex.Replace(source, string.Empty).GetHashCode();
                  if (int.Parse(match.Groups[2].Value) == hash) continue;
                  source = regex.Replace(source, string.Format("Version = {0};//{1}", int.Parse(match.Groups[1].Value) + 1, hash));
                  File.WriteAllText(file.ItemSpec, source);
              }
          ]]></Code>
      </Task>
    </UsingTask>
    <Target Name="BeforeBuild">
      <Version Files="@(Compile)" />
    </Target>
