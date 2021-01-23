        var rads = panel1.Controls.OfType<RadioButton>(); // Get all radioButtons of desired panel
        rads.OrderBy(r => r.Top); // sort them. Please specify what you mean "next" here. I assume that you need next one at the bottom
        // find first checked and set checked for next one
        for (int i = 0; i < rads.Count()-1; i++) 
        {
            if (rads.ElementAt(i).Checked)
            {
                rads.ElementAt(i + 1).Checked = true; 
                return;
            }
        }
