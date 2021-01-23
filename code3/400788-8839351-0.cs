    public IEnumerable<Person> Find(IEnumerable<Person> input, Func<Person, bool> predicate) {
        return input.Select(p => 
            {
                var thisLevel = new List<Person>();
                if(predicate(p))
                    thisLevel.Add(p);
				
                return thisLevel.Union(Find(p.People ?? new List<Person>(), predicate));
            }
        ).SelectMany(p => p);
    }
