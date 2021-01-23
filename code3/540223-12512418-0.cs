                private Dictionary<int, string> _dict;
        		protected Dictionary<int, string> CountryDictionary
        		{
        			get
        			{
        				if (_dict == null)
        				{
        					_dict = new Dictionary<int, string>();
        					_dict.Add(1, "UK");
        					_dict.Add(12, "Australia");
        					// and so on
        				}
        
        				return _dict;
        			}
        		}
        
        		public class PostCodeVerifyMandatory : IPostCodeVerifyMandatory
        		{
        			public bool IsPostCodeRequired(int countryId, string region)
        			{
        				return CountryDictionary.ContainsKey(countryId);
        			}
        		}
