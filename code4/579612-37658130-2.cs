    	public void updateDataOfListStoreInTreeView(ListStore mListstore, int ColumnNumber, params string[] str)
		{
			try {
				bool bUpdated = false;
				TreeIter tmpTreeIter; 
				mListStore.GetIterFirst(out tmpTreeIter);
				object o = mListStore.GetValue(tmpTreeIter, ColumnNumber);
				while(o!=null)
				{
					if(o.ToString()==str[ColumnNumber].ToString()) {
						mListStore.SetValues(tmpTreeIter,str); // update row
						bUpdated=true;
                        break;
					}
					if(mListStore.IterNext(ref tmpTreeIter)) {
						o = mListStore.GetValue(tmpTreeIter, ColumnNumber);
					}
					else 
						o = null;
				}
				if(!bUpdated)  
					mListStore.AppendValues (str); // Add some data to the store
			}
			catch (Exception e)
			{
				Console.WriteLine("WARNING: adding to treeview caused exception");
			}
		}
