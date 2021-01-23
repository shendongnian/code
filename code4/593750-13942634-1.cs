    		/// <summary>
		/// group member enumeration, simple and fast for large AD groups
		/// </summary>
		/// <param name="deGroup"></param>
		/// <returns>list if distinguished names</returns>
		public static List<string> GetMemberList(DirectoryEntry deGroup)
		{
			List<string> list = new List<string>();
			DirectoryEntry entry = deGroup;
			uint rangeStep = 1000;
			uint rangeLow = 0;
			uint rangeHigh = rangeLow + (rangeStep - 1);
			bool lastQuery = false;
			bool quitLoop = false;
			do
			{
				string attributeWithRange;
				if (!lastQuery)
				{
					attributeWithRange = String.Format("member;range={0}-{1}", rangeLow, rangeHigh);
				}
				else
				{
					attributeWithRange = String.Format("member;range={0}-*", rangeLow);
				}
				using (DirectorySearcher searcher = new DirectorySearcher(entry))
				{
					searcher.Filter = "(objectClass=*)";
					//searcher.Filter = LdapObjectMgr.filterDisabledUsers;
					searcher.PropertiesToLoad.Clear();
					searcher.PropertiesToLoad.Add(attributeWithRange);
					SearchResult results = searcher.FindOne();
					foreach (string res in results.Properties.PropertyNames)
					{
						//list the property names
						System.Diagnostics.Debug.WriteLine(res.ToString());
					}
					if (results.Properties.Contains(attributeWithRange))
					{
						foreach (object obj in results.Properties[attributeWithRange])
						{
							//Console.WriteLine(obj.GetType());
							if (obj.GetType().Equals(typeof(System.String)))
							{
							}
							else if (obj.GetType().Equals(typeof(System.Int32)))
							{
							}
							//Console.WriteLine(obj.ToString());
							list.Add(obj.ToString());
						}
						if (lastQuery)
						{
							quitLoop = true;
						}
					}
					else
					{
						if (lastQuery == false)
						{ lastQuery = true; }
						else
						{ quitLoop = true; }
					}
					if (!lastQuery)
					{
						rangeLow = rangeHigh + 1;
						rangeHigh = rangeLow + (rangeStep - 1);
					}
				}
			}
			while (!quitLoop);
			return list;
		}
