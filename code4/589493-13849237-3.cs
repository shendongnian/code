    public class Foo{
        private MyDB _db;
        private Foo _foo;
        public FooObject(MyDB dbContext)
		{
			_db = dbContext;
		}
		public static FooObject GetFooObject(int FooID, MyDB db){
			bool closeFlag = false;
			
			//if null was passed in, then we will create our own connection and manage it
			if (db == null)
			{
				_db = new MyDB();
				closeFlag = true;
			} else {
				//otherwise, we set our local variable
				_db = db;
			}
			//from now on, all queries are done using the local variable
			var _f = _db.Foos
				.Include("x")
				.Include("y")
				.Include("z")
				.SingleOrDefault(f => f.FooID == FooID);
			var fo = FooObjectFromFoo(_f, db);
			if (closeFlag)
				db.Dispose();
			return fo;
		}
		// This copies all of the values from Foo and puts the into a FooObject
		public static FooObject FooObjectFromFoo(Foo f, MyDB dbContext){
			if (l == null)
				return null;
			// note that we pass the dbContext to the constuctor
			FooObject _f = new FooObject(dbContext){
				_foo = f,
				...
				//note x, y, and z are the other EF "table references".  I'm not sure what you technically call them.
				x = f.x,
				y = f.y,
				z = f.z
			};
			
			return _f;
		}
		
		
		//we call this to save the changes when we're done
		public bool Save(){
			bool close = false;	
			bool retval = true;
			MyDB db = _db;
			//remember we set _db in the constructor 			
			if (db == null) {
				db = new MyDB();
				close = true;
			}
			try
			{
				// a reference to this row should have been saved in _foo if we loaded it from the db.
				// take a look at FooObjectFromFoo
				if (_foo == null)
				{
					_foo = db.Foos.SingleOrDefault(x => x.FooID == _FooID);
				}
				if (_foo == null)
				{
					_foo = new Foo();
				}
				//copy all my object values back to the EF Object
				_foo.blah = blah;
				_foo.x = x;
				_foo.y = y;
				try
				{
					//save the new one.
					db.SaveChanges();
				}
				catch (DbEntityValidationException dbEx)
				{
					TransactionResult.AddErrors(dbEx);
					retval = false;
				}
			}
			catch { throw new Exception("Something went wrong here.");}
			finally { if (close) db.Dispose(); } //if we created this connection then let's close it up.
		}
    }
