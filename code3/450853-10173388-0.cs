	public void Add(object target)
	{
		this.Set(target.GetType()).Attach(target);
		this.Entry(target).State = System.Data.EntityState.Added;
	}
	public void Modify(object target)
	{
		this.Set(target.GetType()).Attach(target);
		this.Entry(target).State = System.Data.EntityState.Modified;
	}
