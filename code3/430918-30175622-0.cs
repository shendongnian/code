                int i = counter;
				cellTextRenderer.Edited  +=( sender,  args) => {
					TreePath path = new TreePath (args.Path);
					TreeIter iter;
					musicListStore.GetIter (out iter, path);	
					//i is column number
					musicListStore.SetValue (iter, i, args.NewText);
				};
