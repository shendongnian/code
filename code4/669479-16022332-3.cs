    public void EditPerson(Person person)
    {
        _context.Entry(person).State = EntityState.Modified;
        _context.SaveChanges();
    }
