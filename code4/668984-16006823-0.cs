    Collections.sort(list, new Comparator<ListItem>() {
        public int compare(ListItem a, ListItem b) {
            DateTime aDate = DateTime.Parse(a.split(null)[0]);
            DateTime bDate = DateTime.Parse(b.split(null)[0]);
            if(DateTime.Compare(aDate, bDate) < 0)
                return a;
            else
                return b;
        }
    });
