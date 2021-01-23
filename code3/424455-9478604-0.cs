    for (int i = 0; i < agedValues.Count; i++)
    {
        View view = this.LayoutInflater.Inflate(
                        Resource.Layout.aged_summary_list_item, 
                        relativeAgedSummary, false);
        var row = agedValues.ElementAt(i);
        // the logic here...
        relativeAgedSummary.AddView(view);
    }
