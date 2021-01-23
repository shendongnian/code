        public partial class MyTable
		{
			private bool blockOnCanShowChanging = false;
			partial void OnCanShowChanging(bool? value)
			{
				if (blockOnCanShowChanging)
				{
					return; //Recursive call...just return
				}
				if (some_condition)
				{
					//Turn on bool to avoid recusive call
					blockOnCanShowChanging = true;
					
					this.CanShow = value;
					//reset bool to allow subsequent calls to OnCanShowChanging
					blockOnCanShowChanging = false;
				}
				//else -> avoid column data change
			}
		}
