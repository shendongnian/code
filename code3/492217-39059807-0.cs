    public void AddPerson(string personId, Person personData)
            {
                Throw.IfNullOrEmpty(personId, nameof(personId));
                Throw.IfNull(personData, nameof(personData));
..
    public void Compute(int generation)
            {
                Throw.IfNot(() => generation > 100);
