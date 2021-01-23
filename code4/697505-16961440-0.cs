		private static IEnumerable<IntPtr> GetChildWindows(IntPtr parent)
		{
			List<IntPtr> result = new List<IntPtr>();
			GCHandle listHandle = GCHandle.Alloc(result);
			try
			{
				NativeMethods.EnumWindowProc childProc = new NativeMethods.EnumWindowProc(EnumWindow);
				NativeMethods.EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
			}
			finally
			{
				if(listHandle.IsAllocated)
				{
					listHandle.Free();
				}
			}
			return result;
		}
		/// <summary>
		/// Callback method to be used when enumerating windows.
		/// </summary>
		/// <param name="handle">Handle of the next window</param>
		/// <param name="pointer">Pointer to a GCHandle that holds a reference to the list to fill</param>
		/// <returns>True to continue the enumeration, false to bail</returns>
		private static bool EnumWindow(IntPtr handle, IntPtr pointer)
		{
			GCHandle gch = GCHandle.FromIntPtr(pointer);
			List<IntPtr> list = gch.Target as List<IntPtr>;
			if(list == null)
			{
				throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
			}
			list.Add(handle);
			// You can modify this to check to see if you want to cancel the operation, then return a null here
			return true;
		}
    private DataGridView Grid()
    {
    IEnumerable<IntPtr> a = GetChildWindows(handle);
    			foreach(IntPtr b in a)
			{
				Control c = Control.FromHandle(b);
				if(c == null)
				{
					continue;
				}
				try
				{
					if(c.Name != "DataGridView")
					{
						continue;
					}
					DataGridView dv = c as DataGridView;
					if(dv != null)
					{
						return dv;
					}
				}
				catch
				{
					// It is safe to suppress errors here.
				}
			}
}
