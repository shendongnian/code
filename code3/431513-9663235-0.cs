                     // find all T in the VisualTree
                     public static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) 
			where T : DependencyObject
		{
			List<T> foundChilds = new List<T>();
			int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
			for (int i = 0; i < childrenCount; i++)
			{
				var child = VisualTreeHelper.GetChild(parent, i);
				T childType = child as T;
				if (childType == null)
				{
					foreach(var other in FindVisualChildren<T>(child))
						yield return other;
				}
				else
				{
					yield return (T)child;
				}
			}
		}
