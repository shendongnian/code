    public Save() {
        DatabaseContect ct = new DatabaseContext();
        ct.Entry(psn).State = EntityState.Modified;
        ct.SaveChanges();
    }
