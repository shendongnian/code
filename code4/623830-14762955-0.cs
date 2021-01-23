			NSError err;
			ABAddressBook ab = ABAddressBook.Create(out err);
			Dictionary<string,List<string>> phones = new Dictionary<string,List<string>> ();
			ab.RequestAccess(delegate(bool granted,
			                       NSError error) {
				if (granted)
				{
					foreach (ABPerson p in ab.GetPeople()) {
						foreach (var phoneNumber in p.GetPhones().GetValues()) {
							if (phones.ContainsKey(phoneNumber))
							{
								phones[phoneNumber].Add (p.FirstName + " " + p.LastName);
							}
							else
							{
								phones.Add (phoneNumber,new List<string>() { p.FirstName + " " + p.LastName });
							}
						}
						
					}
					var dupes = (from x in phones where x.Value.Count() > 1 select x);
					foreach(var d in dupes)
					{
						Console.Write(d.Key + ": ");
						foreach (string s in d.Value)
						{
							Console.Write(s + ", ");
						}
						Console.WriteLine();
					}
				}
			});
