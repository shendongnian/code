            VCProject prj;
            int count = _applicationObject.Solution.Projects.Count;
            for(int i = 1; i <= count; i++ )
            {
                //Start counting at one for some reason
                prj = (Microsoft.VisualStudio.VCProjectEngine.VCProject)_applicationObject.Solution.Projects.Item(i).Object;
                foreach (VCFile item in prj.Files)
                {
                    //Item is the file, do whatever you want with it here
                }
            }
