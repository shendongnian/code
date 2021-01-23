    public bool validateAllHitsCompareAtBats()
    {
         int hits = int.Parse(txtSingles.Text) + int.Parse(txtDoubles.Text) + int.Parse(txtTriples.Text) + int.Parse(txtHomeRuns.Text);
    
         return int.Parse(txtAtBats.Text) >= hits;
    }
