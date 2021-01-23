	public class ListPresentationViewModel: MvxViewModel 
	{
		private readonly ISQLService _sqlSvc;
		public ListPresentationViewModel (ISQLService sqlService)
		{
			_sqlSvc = sqlService;
			MenuCollection = WrapConverter.ConvertToWrapperClass (_sqlSvc.MenuItemGetAll(), this);
		}
		private int _catId;
		public int CategorieId { 
			get{ return _catId;} 
			set{ 
				_catId = value;
				ChangeMenuCollection ();
			}
		}
		private void ChangeMenuCollection()
		{
			MenuCollection = WrapConverter.ConvertToWrapperClass (_sqlSvc.MenuItemByCategorie (_catId), this);
		}
		private List<MenuItemWrap> _menuCollection = new List<MenuItemWrap> ();
		public List<MenuItemWrap> MenuCollection {
			get{ return _menuCollection;}
			set {
				_menuCollection = value;
				RaisePropertyChanged (() => MenuCollection);
			}
		}
		private IMvxCommand _orderBtnClick;
		public IMvxCommand OrderBtnClick {
			get {
				_orderBtnClick = _orderBtnClick ?? new MvxCommand<MenuItem> (btnClick);
				return _orderBtnClick;
			}
		}
		public void btnClick (MenuItem item)
		{
			//Do Something
		}
	}    	
