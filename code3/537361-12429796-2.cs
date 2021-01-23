            var chBoxList= new CheckedListBox();
            chBoxList.Items.Add(new ListItem("One", "1"));
            chBoxList.Items.Add(new ListItem("Two", "2"));
            chBoxList.SetItemChecked(1, true);
            var checkedItems = chBoxList.CheckedItems;
            var chkText = ((ListItem)checkedItems[0]).Text;
            var chkValue = ((ListItem)checkedItems[0]).Value;
            MessageBox.Show(chkText);
            MessageBox.Show(chkValue);
