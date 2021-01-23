    <script language="C#">
             <code><![CDATA[
             public static void ScriptMain(Project project) {
                 string contents = "";
                 StreamReader reader = new StreamReader("AssemblyInfo.cs");
                 contents = reader.ReadToEnd();
                 reader.Close();
                 string replacement = string.Format(
                     "AssemblyVersion(\"{0}.{1}.{2}.{3}\")]",
                     project.Properties["build.major"],
                     project.Properties["build.minor"],
                     project.Properties["build.build"],
                     project.Properties["svn.revision"]
                 );  
    
                    string newText = Regex.Replace(contents, @"AssemblyVersion\("".*""\)\]", replacement);
                 StreamWriter writer = new StreamWriter(project.Properties["filename"], false);
                 writer.Write(newText);
                 writer.Close();
             }        
             ]]></code>
             </script>
