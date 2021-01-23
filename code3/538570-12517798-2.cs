                // Our Click Action
		partial void btnClick (NSObject sender)
		{
			var p = new Person("John Doe",18);
			p.Children.Add(new Person("Jane Doe",10));
			var ds = lvMain.DataSource as MyDataSource;
			ds.Persons.Add(p);
			lvMain.ReloadData();
		}
		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();
			lvMain.DataSource = new MyDataSource();
		}
