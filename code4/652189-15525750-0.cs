    btnAddContact.Click += delegate {
				nameList.Add(nameText.Text + " " + ipText.Text);
				var myAdapter = new ArrayAdapter(this, Resource.Layout.TextViewItem, nameList);
				contactView.Adapter = myAdapter;
				myAdapter.NotifyDataSetChanged();
				nameText.Text = "";
				ipText.Text = "";
				};
