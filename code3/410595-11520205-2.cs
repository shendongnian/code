    			public class AnotherClass
			{
				public List<UserRole> Roles()
				{
					 List<UserRole> outList = new List<UserRole>();
					 //Fill the List with your UserRoles
					 foreach (object MyData in MyDataList)
					 {
						 UserRole myRole = new UserRole();
						 outList.Add(myRole);
					 }
					 return outList;
				}
			}
