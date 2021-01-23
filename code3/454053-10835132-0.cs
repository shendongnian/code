    List<string> assemblyNames = new List<string>();
    if (teamProject != null) {
        ICoverageAnalysisManager coverageAnalysisManager = teamProject.CoverageAnalysisManager;
        if (coverageAnalysisManager != null) {
            IBuildCoverage[] buildCoverage = coverageAnalysisManager.QueryBuildCoverage(buildURI, CoverageQueryFlags.Modules);
            List<string> assemblyNames = new List<string>();
            foreach (IBuildCoverage buildCoverageDetails in buildCoverage) {
                foreach (IModuleCoverage module in buildCoverageDetails.Modules) {
    					assemblyNames.Add(module.Name);
                }
            }
        }
    }
