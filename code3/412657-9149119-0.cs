     public void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs args)
            {
                const string PRIVILAGE1 = "Privilege 1";
                const string PRIVILAGE2 = "Privilege 2";
                const string PRIVILAGE3 = "Privilege 3";
    
                var checkBoxList = sender as CheckBoxList;
                if (checkBoxList == null) return;
                var selectedItems = checkBoxList.Items.Cast<ListItem>().Where(x => x.Selected).ToList();
    
                if (!selectedItems.Any()) return;
                ImageButton1.Visible = selectedItems.Any(x => x.Value.Equals(PRIVILAGE1, StringComparison.OrdinalIgnoreCase));
                ImageButton2.Visible = selectedItems.Any(x => x.Value.Equals(PRIVILAGE2, StringComparison.OrdinalIgnoreCase));
                ImageButton3.Visible = selectedItems.Any(x => x.Value.Equals(PRIVILAGE3, StringComparison.OrdinalIgnoreCase));
        }
