    public decimal[] GetPreprocData()
    {
            int i = 3;
            decimal[] data = new decimal[9];
    
            data[0] = (start.Value.Hour * 3600) + (start.Value.Minute * 60);
            data[1] = duration.Value;
            data[2] = flowRate.Value;
    
            foreach (NumericUpDown nud in gbHTF.Controls.OfType<NumericUpDown>().OrderBy(nud => nud.TabIndex))
            {
                data[i] = nud.Value;
                i++;
            }
    
            return preprocData;
    }
