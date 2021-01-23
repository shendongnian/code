   		public static void beAddedTo<T>(this T item, Dictionary<int, T> dic) where T : m.lib.RandId
		{
			Random ran = new Random();
			var ri = ran.Next();
			while (Program.DB.Rooms.ContainsKey(ri)) ri = ran.Next();
			item.Id = ri;
			dic.Add(item.Id, item);
		}
