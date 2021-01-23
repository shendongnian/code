	public class XUser
	{
		public virtual int Id { get; set; }
		...
		public virtual ISet<XUserHasXFunction> XUserHasXFunctions { get; set; }
		public XUser()
		{
			XUserHasXFunctions = new HashedSet<XUserHasXFunction>();
		}
		public virtual void AddXFunction(XFunction xFunction, int isActive)
		{
			var xUserHasXFunction = new XUserHasXFunction()
										{
											XUser = this,
											XFunction = xFunction,
											IsActive = isActive,
											DeployedDate = DateTime.Now
										};
			if (XUserHasXFunctions.Contains(xUserHasXFunction) && xFunction.XUserHasXFunctions.Contains(xUserHasXFunction))
			{
				return;
			}
			XUserHasXFunctions.Add(xUserHasXFunction);
			xFunction.XUserHasXFunctions.Add(xUserHasXFunction);
		}
		public virtual void RemoveXFunction(XFunction xFunction)
		{
			var xUserHasXFunction = XUserHasXFunctions.Single(x => x.XFunction == xFunction);
			XUserHasXFunctions.Remove(xUserHasXFunction);
			xFunction.XUserHasXFunctions.Remove(xUserHasXFunction);
		}
	}
	public class XFunction
	{
		public virtual int Id { get; set; }
		...
		public virtual ISet<XUserHasXFunction> XUserHasXFunctions { get; set; }
		public XFunction()
		{
			XUserHasXFunctions = new HashedSet<XUserHasXFunction>();
		}
		public virtual void AddXUser(XUser xUser, int isActive)
		{
			var xUserHasXFunction = new XUserHasXFunction()
										{
											XUser = xUser,
											XFunction = this,
											IsActive = isActive,
											DeployedDate = DateTime.Now
										};
			if (XUserHasXFunctions.Contains(xUserHasXFunction) && xUser.XUserHasXFunctions.Contains(xUserHasXFunction))
			{
				return;
			}
			XUserHasXFunctions.Add(xUserHasXFunction);
			xUser.XUserHasXFunctions.Add(xUserHasXFunction);
		}
		public virtual void RemoveXUser(XUser xUser)
		{
			var xUserHasXFunction = XUserHasXFunctions.Single(x => x.XUser == xUser);
			XUserHasXFunctions.Remove(xUserHasXFunction);
			xUser.XUserHasXFunctions.Remove(xUserHasXFunction);
		}
	}
    public class XUserHasXFunction
    {
        public virtual int Id { get; set; }
		...
        public virtual DateTime DeployedDate { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as XUserHasXFunction;
            if (t == null)
                return false;
            return XUser == t.XUser && XFunction == t.XFunction;
        }
        public override int GetHashCode()
        {
            return (XUser.Id + "|" + XFunction.Id).GetHashCode();
        }
    }
