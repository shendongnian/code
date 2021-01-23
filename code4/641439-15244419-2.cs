            //Erstellen der Codefiles (XAML und CodeBehind)
            this.CreateCodeFile(codeBehind);
            this.CreateXamlFile(xaml);
            //Erstellen der project file
            this.CreateProjectFile();
            //Build der DLL
            //using (var buildManager = BuildManager.DefaultBuildManager)
            using (var buildManager = new BuildManager())
            {
                var result = buildManager.Build(this.CreateBuildParameters(), this.CreateBuildRequest());
                if (result.OverallResult == BuildResultCode.Success)
                {
                    return this.LoadWindowFromDll(FolderPath + DllRelativeFilePath + NamespaceName + DllFileExtension);
                }
            }
            //Error handling
            var stringbuilder = new StringBuilder();
            using (var reader = new StreamReader(DebuggerLogFileName))
            {
                stringbuilder.Append(reader.ReadToEnd());
            }
            throw new CompilerException(stringbuilder.ToString());
        }
