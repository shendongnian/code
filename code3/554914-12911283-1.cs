	public class Favorites: ApplicationSettingsBase
	{
		private String[] favoritesList;
		[UserScopedSetting()]
		[System.Xml.Serialization.XmlElementAttribute("FavoritesList")]
		[DefaultSettingValue("")]
		public String[] FavoritesList
		{
			get
			{
				return (this.favoritesList);
			}
			set
			{
				this.favoritesList = value;
			}
		}
	}
