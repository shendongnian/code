	public IQueryable<EditSetting> GetEditSettings()
	{
		return from p in SettingRepository
			select new EditSetting{
					Foo = p.Foo,
					Bar = p.Bar,
					//etc...
			};
	}
	
