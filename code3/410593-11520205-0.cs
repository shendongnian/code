 			public static class CurrentUser           
			{              
				public static int UserID { get; set; }              
				public static string UserName { get; set; 	}
				public static List<UserRole> Role()
				{
					//Call another class with method to fill the list
					AnotherClass _anotherClass = new AnotherClass();
					return _anotherClass.Roles();
					
				}
			}  
