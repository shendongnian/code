            var item = dte.Solution.Projects.GetEnumerator();
            while (item.MoveNext())
            {
                var project = item.Current as EnvDTE.Project;
                if (project == null)
                {
                    continue;
                }
                ...
            }
