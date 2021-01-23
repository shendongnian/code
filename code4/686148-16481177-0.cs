    void My_Page_Load(object sender, EventArgs e)
    {
       BtnCalculate.Attributes.Add("OnClick", "Javascript:CalculateRisk();");
    }
    protected void BtnCalculate_Click(object sender, EventArgs e)
    {
        LblRisk.Visible = true;
        TxtRisk.Visible = true;     
    }
