    int? min = null
    int? max = null;
    int i;
    if (Int32.TryParse(txtMin.Text, out i) min = i;
    if (Int32.TryParse(txtMax.Text, out i) max = i;
    IEnumerable<HomeInfo> result;
    if (min.HasValue && max.HasValue) {
        result = list.Where(h => h.EstimatedValue >= min.Value &&
                                 h.EstimatedValue <= max.Value);
    } else if (min.HasValue) {
        result = list.Where(h => h.EstimatedValue >= min.Value);
    } else if (max.HasValue) {
        result = list.Where(h => h.EstimatedValue <= max.Value);
    } else {
        result = list;
    }
