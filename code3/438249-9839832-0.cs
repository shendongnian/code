    public virtual IEnumerable<IItem> Sections {
        get{
            foreach (var sect in Sections) {
                foreach (var item in sect.Items) {
                    yield return item;
                }
            }
        }
