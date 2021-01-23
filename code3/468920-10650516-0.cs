		Class Form1
		{
			private static Form1 staticInstance = default(Form1);
			Form1()
				{
				staticInstance  = this;
				}
			public static string Status 
			{
				get 
				{ 
				return status; 
				}
				set 
				{
					status = value;
					Refresh();
				} 
			}
			
			private static void Refresh()  // Change signature of function
			{
			    if(staticInstance  != default(Form1)
				staticInstance .lblStatus.Text = Status.ToString();
			}
		
		}
