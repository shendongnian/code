    private List<string> _countryListItems;
    		public List<string> CountryListItems {
    			get {
    				if (_countryListItems == null) {
    					_countryListItems = (List<string>)Session["CountryListItems"];
    					if (_countryListItems == null) {
    						_countryListItems = new List<string>();
    						Session["CountryListItems"] = _countryListItems;
    					}
    				}
    				return _countryListItems;
    			}
    			set { _countryListItems = value; }
    		}
    
    		protected void CountryBuy6_Click(object sender, ImageClickEventArgs e) {
    			CountryListItems.Add("Willie Nelson - Legend - $9");
    		}
