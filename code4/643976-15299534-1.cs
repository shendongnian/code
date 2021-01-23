	/// <summary>
	/// declared as partial for easily coexists with original code
	/// if not used(e.g already declared) then not paste to file
	/// </summary>
	partial class AccountDto /* known members */ {
		public int Accountid;
		public int Userid;
		public String Holdername;
		public int Balance;
		public String Status;
	}
	/// <summary>
	/// declared as partial for easily coexists with original code
	/// if getSearchedAccount is declared with another class name
	/// then just rename the partial class to that name and remove 
	/// all `static`(if that class is non-static) 
	/// the class initializer, then become constructor; remember to 
	/// match the name of class and constructor
	/// </summary>
	partial class AccountDto {
		/// <summary>
		/// declare as static for this demo; 
		/// not necessarily be static if it's declared in another 
		/// class where list is declared
		/// </summary>
		public static List<AccountDto> getSearchedAccount(
			int accountid, int userid,
			String holdername, String type,
			double balance,
			String status
			) {
			var results=new List<AccountDto>();
			// make a copy of IgnoreRules and clear; equivalent to 
			// var matchRules=new Dictionary<String, Func<AccountDto, bool>>();
			// IgnoreRules is not changed with these two statement
			// just prevent to see too many angle braces
			var matchRules=IgnoreRules.ToDictionary(x => x.Key, x => x.Value);
			matchRules.Clear();
			// the parameters only known in this method thus can only added here
			matchRules.Add("accountid", x => accountid==x.Accountid);
			matchRules.Add("userid", x => userid==x.Userid);
			matchRules.Add("holdername", x => holdername==x.Holdername);
			matchRules.Add("balance", x => balance==x.Balance);
			matchRules.Add("status", x => status==x.Status);
			for(int i=0; i<list.Count; i++) {
				var dto=(AccountDto)list[i];
				if((from ignoreRule in IgnoreRules
					from matchRule in matchRules
					where ignoreRule.Key==matchRule.Key
					where !ignoreRule.Value(dto)
					select matchRule.Value(dto)).All(x => x))
					results.Add(dto);
			}
			return results;
		}
		/// <summary>
		/// criteria for `don't test for matching`
		/// </summary>
		public static Dictionary<String, Func<AccountDto, bool>> IgnoreRules {
			get;
			set;
		}
		/// <summary>
		/// use class initializer to add common IgnoreRules
		/// </summary>
		static AccountDto() {
			IgnoreRules=new Dictionary<String, Func<AccountDto, bool>>();
			IgnoreRules.Add("accountid", x => 0==x.Accountid);
			IgnoreRules.Add("userid", x => 0==x.Userid);
			IgnoreRules.Add("holdername", x => String.IsNullOrEmpty(x.Holdername));
			IgnoreRules.Add("balance", x => 0==x.Balance);
			IgnoreRules.Add("status", x => String.IsNullOrEmpty(x.Status));
		}
		/// <summary>
		/// declare as static for this demo; 
		/// not necessarily be static if it's declared in another 
		/// class where getSearchedAccount is declared
		/// </summary>
		public static List<AccountDto> list=new List<AccountDto>();
	}
