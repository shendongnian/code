    var designationsByDate = allianceDesignations.GroupBy(designation => designation.UpdateDue).OrderBy(values => values.Key);
    string[] rowsOfData = designationsByDate.Select(designationByDate => {
        string annual = designationByDate.Aggregate(string.Empty, (acc, designation) => acc + "/" + designation.Name);
        return string.Format("Annual {0} Update {1}", annual, designationByDate.Key);
    });
