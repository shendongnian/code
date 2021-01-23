    public void FixUp(EntityContext c)
    {
      for (int i = 0; i < this.Addresses.Count; i++)
      {
        var existing = c.Addresses.SingleOrDefault(a => a.Id = this.Addresses[i].Id);
        if (existing != null)
        {
          this.Addresses[i] = existing;
        }
      }
    }
    using (var k = new EntityContext())
    {
      newPerson.FixUp(k);
      k.Persons.Add(newPerson);
      k.SaveChanges();
    }
