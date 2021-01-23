    IEnumerable<f_results> foundfiles = new List<f_results>();
    var filters = new List<Func<f_results, bool>>();
    if (fsize.Text.Trim() != "")
    {
        long sz = long.Parse(fsize.Text);
        filters.Add(x => x.size >= sz);
    }
    if (adate.Text.Trim() != "")
    {
        DateTime test = DateTime.Parse(adate.Text);
        filters.Add(x => x.adate >= test);
    }
    foreach (var filter in filters)
    {
        var filterToApply = filter;
        foundfiles = foundfiles.Where(filterToApply);
    }
    finalResults = new BindingList<f_results>(foundfiles);
