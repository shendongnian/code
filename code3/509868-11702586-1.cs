    protected void gvGeneralDiagnosis_SelectedIndexChanged(object sender, EventArgs e)
    {
        string generalDiagnosis = gvGeneralDiagnosis.DataKeys[gvGeneralDiagnosis.SelectedIndex].Values["ICD10Name"].ToString();
        gvSpecificDiagnosis.DataSource = ICD10
            .Where(i => i.ICD10Code.Contains(generalDiagnosis))
            .Select(i => new { i.ICD10Name, i.ICD10Code });
        gvSpecificDiagnosis.DataBind();
    }
