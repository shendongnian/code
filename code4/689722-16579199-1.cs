	public IEnumerable<EditSetting> GetEditSettingsById(IList<string> ids)
	{
		var ret =  from p in SettingRepository
				where ids.Contains(p.Id)
				select new EditSetting{
						Foo = p.Foo,
						Bar = p.Bar,
						//etc...
				};
		return ret.ToList();
	}
