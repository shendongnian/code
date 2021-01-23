    void radGridView_GroupSummaryEvaluate(object sender, Telerik.WinControls.UI.GroupSummaryEvaluationEventArgs e)
    {
        if ((e.SummaryItem.Name == "Rotulo") || (e.SummaryItem.Name == "Termino"))
        {
            e.FormatString = e.Value.ToString();
        }
    }
