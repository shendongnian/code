        int sum = 0;
        for (int i = 0; i < dgTestSteps.Rows.Count; ++i)
        {
           sum += Int.Parse(dgTestSteps.Rows[i].Cells[1].Value.ToString());
        }
        lblTotalTime.Text = sum.To String();
