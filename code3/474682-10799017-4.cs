    Comparison<ContentItemViewModel> comparison = new Comparison<ContentItemViewModel>(
                (p,q) =>
                {
                    DateTime first = DateTime.Parse(p.DateAndTime);
                    DateTime second = DateTime.Parse(q.DateAndTime);
                    if (first == second)
                        return 0;
                    if (first > second)
                        return 1;
                    return -1;
                });
            List<ContentItemViewModel> tempList = _contentTree.ToList();
            tempList.Sort(comparison);
            _contentTree = new ObservableCollection<ContentItemViewModel>(tempList);
