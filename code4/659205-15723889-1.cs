            listbox.Items.Add("Day 1, Approximate Population:" + txtStartingNumberOfOrganisms.Text);
            int ApproximatePopulation = Convert.ToInt16(txtStartingNumberOfOrganisms.Text);             
            for (int i = 2; i <= numOfDays - 1; i++)
            {
                ApproximatePopulation = ApproximatePopulation + ((ApproximatePopulation * Convert.ToDouble(txtDailyIncrease.text)) / 100);
                listbox.Items.Add("Day " + i + ", Approximate Population:" + Convert.ToString(ApproximatePopulation));
            }
    
