    public IEnumerable<Person> Find (Func<Person, bool> predicate) {
        foreach (var p in family.Person) {
            if(predicate(p)) {
                yield return p;
            }
        }
    }
