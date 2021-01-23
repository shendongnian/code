    public class SummaryTeamLevelViewModel
    {
        public SummaryTeamLevelViewModel(IList<PillarsOfCultureTeamLevelDTO> pillarofcultureteamlevel,
                                        IList<RetentionDriverTeamLevelDTO> retentiondriverteamlevel,
                                        IList<EmployeeTeamLevelSummaryDTO> employeeteamlevelsummarylist)
        {
            this.pillarofcultureteamlevel = pillarofcultureteamlevel;
            this.retentiondriverteamlevel = retentiondriverteamlevel;
            this.employeeteamlevelsummarylist = employeeteamlevelsummarylist;
        }
    
        public IList<PillarsOfCultureTeamLevelDTO> pillarofcultureteamlevel { get; set; }
    
        public IList<RetentionDriverTeamLevelDTO> retentiondriverteamlevel { get; set; }
    
        public IList<EmployeeTeamLevelSummaryDTO> employeeteamlevelsummarylist { get; set; }
    
    }
