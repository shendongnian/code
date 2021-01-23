    using System.Collections.Generic;
    namespace OfficeUtils.Stack
    {
	/// <summary>
	/// Stack of COM objects to be released
	/// </summary>
	public abstract class ComObjectsStack
	{
		private Stack<object> comObjects = new Stack<object>();
		private int mark = 0;
		/// <summary>
		/// Releases all the remaining COM objects
		/// </summary>
		~ComObjectsStack()
		{
			if (comObjects.Count > 0)
				ReleaseAll();
			comObjects = null;
		}
		/// <summary>
		/// Add a new object to the stack to be released
		/// </summary>
		/// <param name="obj">Nuevo objeto a liberar</param>
		public void Push(object obj)
		{
			comObjects.Push(obj);
		}
		/// <summary>
		/// Release the last object in the stack
		/// </summary>
		public void Pop()
		{
			Release(1);
		}
		/// <summary>
		/// Mark for future use of ReleaseUpToMark
		/// </summary>
		public void Mark()
		{
			mark = comObjects.Count;
		}
		/// <summary>
		/// Release up to mark
		/// </summary>
		/// <returns>Number of released objects</returns>
		public int ReleaseUpToMark()
		{
			int numberObjects = comObjects.Count - mark;
			if (numberObjects > 0)
			{
				Release(numberObjects);
				return numberObjects;
			}
			else
			{
				return 0;
			}
		}
		/// <summary>
		/// Release all the objects in the stack
		/// </summary>
		public void ReleaseAll()
		{
			if (comObjects != null)
				Release(comObjects.Count);
		}
		/// <summary>
		/// Release the last numberObjects objects in stack
		/// </summary>
		/// <param name="numberObjects">Number of objects to release</param>
		private void Release(int numberObjects)
		{
			for (int j = 0; j < numberObjects; j++)
			{
				object obj = comObjects.Pop();
				int i = 1;
				do
				{
					i = System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
				}
				while (i > 0);
				obj = null;
			}
		}
	}
