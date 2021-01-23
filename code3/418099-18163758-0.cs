    int sum = 0;
            for (int i = 0; i < dgTestSteps.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgTestSteps.Rows[i].Cells[0].Value);
                
            }
            lblTotalTime.Text = sum.ToString();
