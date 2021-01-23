	Dictionary<int,Item> dic = new Dictionary<int,Item>();
	foreach(Item item in items)
	{
		Item parent;
		if(item.ParentId!=null && dic.TryGetValue(item.ParentId, out parent))
			parent.SubItems.Add(item);
		else
			dic.Add(item.Id, item);
	}
	Item root = dic[1];
