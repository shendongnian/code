    using (Context context = new Context())
    {
      context.As.Attach(A);
      context.Entry(A).State = EntityState.Added;
      context.SaveChanges();
    }
