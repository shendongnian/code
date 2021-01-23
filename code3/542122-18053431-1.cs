		public void stackoverflow_BusinessCard_FlowLayoutPanel()
		{
			List<string> labels = new List<string>();
			
			labels.Add("Title");
			labels.Add("Description");
			labels.Add("Phone");
			labels.Add("Email");
			labels.Add("Address");
			labels.Add("label6");
			labels.Add("labelN");
			
			
			ComboItem cItem = new ComboItem();
			
			cItem.Collection = new List<string>();
			cItem.Collection.Add("Option1");
			cItem.Collection.Add("Option2");
			
			cItem.Name = "comboName";
			cItem.SelectedIndex = 0;
			cItem.Text = cItem.Collection[cItem.SelectedIndex];
			cItem.Location = new Point(50, 265);
			cItem.size = new Size(100,21);
			
			List<ComboItem> comboItems = new List<ComboItem>();
			comboItems.Add(cItem);
			
			
			SerializableBusinessCard bCard1 = new SerializableBusinessCard();
			
			bCard1.Name			= "CompanyXYZ_BlueTheme";
			bCard1.Company		= "CompanyXYZ";
			bCard1.Labels	 	= labels;
			bCard1.ComboBoxes	= comboItems;
			
			SerializeObjectXML("BusinessCard_392.xml",bCard1);
			
			SerializableBusinessCard loaded = DeserializeBusinessCardXML("BusinessCard_392.xml");
		}
