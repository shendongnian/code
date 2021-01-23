	ListBox lb = new ListBox();
	lb.Items.Add("chat member");
	TabItem ti = new TabItem();
	ti.Header = "Private Chats";
	ti.Content = lb;
	TabControl tc = new TabControl();
	tc.Items.Add(ti);
