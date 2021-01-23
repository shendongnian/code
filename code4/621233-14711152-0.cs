        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {               
            if(e.StateChanged.ToString() == "Displayed")
            {
                DataClasses1DataContext getIsEmployed = new DataClasses1DataContext();
                var result = from a in getIsEmployed.writers
                             where a.name == dataGridView1.Rows[e.Row.Index].Cells["nameDataGridViewTextBoxColumn"].Value.ToString()
                             select a;
                foreach (var b in result)
                {
                    if (b.IsEmployed == true)
                    {
                        int val1 = Convert.ToInt32(dataGridView1.Rows[e.Row.Index].Cells["articlesPerWeekDataGridViewTextBoxColumn"].Value);
                        decimal val2 = val1 * 300;
                        decimal hourlyRate = Convert.ToDecimal(dataGridView1.Rows[e.Row.Index].Cells["hourlyRateDataGridViewTextBoxColumn"].Value);
                        int contractedEmployedHours = Convert.ToInt32(dataGridView1.Rows[e.Row.Index].Cells["hoursDataGridViewTextBoxColumn"].Value);
                        decimal employedWage = (((hourlyRate * contractedEmployedHours) * 52) / 12);
                        decimal employedBonusPerArticle = Convert.ToDecimal(dataGridView1.Rows[e.Row.Index].Cells["bonusDataGridViewTextBoxColumn"].Value);
                        decimal maximumEmployedBonus = (((val1 * employedBonusPerArticle) * 52) / 12);
                        decimal maximumEmployedLiability = employedWage + maximumEmployedBonus;
                        dataGridView1.Rows[e.Row.Index].Cells["ExpectedWeeklyWords"].Value = val2;
                        dataGridView1.Rows[e.Row.Index].Cells["CostOfContent"].Value = employedWage;
                        dataGridView1.Rows[e.Row.Index].Cells["MaximumBonus"].Value = maximumEmployedBonus;
                        dataGridView1.Rows[e.Row.Index].Cells["MaximumLiability"].Value = maximumEmployedLiability;
                    }
                    else
                    {
                        int val1 = Convert.ToInt32(dataGridView1.Rows[e.Row.Index].Cells["articlesPerWeekDataGridViewTextBoxColumn"].Value);
                        decimal val2 = val1 * 300;
                        int basicCost = Convert.ToInt32(dataGridView1.Rows[e.Row.Index].Cells["articlesPerWeekDataGridViewTextBoxColumn"].Value);
                        int calculatedBasicCost = (((basicCost * 3) * 52) / 12);
                        decimal bonusPerArticle = Convert.ToDecimal(dataGridView1.Rows[e.Row.Index].Cells["bonusDataGridViewTextBoxColumn"].Value);
                        decimal maximumBonus = (((val1 * bonusPerArticle) * 52) / 12);
                        decimal maximumLiability = calculatedBasicCost + maximumBonus;
                        dataGridView1.Rows[e.Row.Index].Cells["ExpectedWeeklyWords"].Value = val2;
                        dataGridView1.Rows[e.Row.Index].Cells["CostOfContent"].Value = calculatedBasicCost;
                        dataGridView1.Rows[e.Row.Index].Cells["MaximumBonus"].Value = maximumBonus;
                        dataGridView1.Rows[e.Row.Index].Cells["MaximumLiability"].Value = maximumLiability;
                    }
                }
            }   
            
        }
