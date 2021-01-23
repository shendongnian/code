    var People = PersonList.Aggregate(
        new List<Person>(),
        (m, n) => {
            m.Add(m, n);
    
            if(n.ShowChildren) {
                m.AddRange(PersonList.Where(x => x.ParentID == n.ID));
            }
    
            return m;
        }
    );
