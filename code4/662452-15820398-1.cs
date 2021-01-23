    private List<string> _countryItems;
    		public List<string> CountryItems {
    			get {
    				if (_countryItems == null) {
    					_countryItems = (List<string>)Session["CountryItems"];
    					if (_countryItems == null) {
    						_countryListItems = new List<string>();
    						Session["CountryItems"] = _countryItems;
    					}
    				}
    				return _countryItems;
    			}
    			set { _countryItems = value; }
    		}
    
    		protected void CountryBuy6_Click(object sender, ImageClickEventArgs e) {
    			CountryItems.Add("Willie Nelson - Legend - $9");
    		}
