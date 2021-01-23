		private MyDb db;
		
		public FooService (){
			var _db = new MyDataContext();
			db = _db.Context;
		}
		public Result ProcessTransaction(int FooId, string comment)
		{
			var foo = FooObject.GetFooObject(FooId,db);
			Result r = foo.ProcessTransaction(comment);
			if (r.Success)
				foo.Save();
			return r;
		}
		
