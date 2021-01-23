    protected void MoveSelectedItems(List<AddedUsers> from, ListBox to)
        {
            if (from.Count == 0)
            {
                return;
            }
            SecurityUserRole sur = new SecurityUserRole();
            ListItem item;
            foreach (var i in from)
            {
                item = new ListItem();
                item.Value = i.UserID;
                item.Text = i.UserName;             
                if (listAllUsers.Items.Contains(item))
                {
                    listAllUsers.Items.Remove(item);
                    listMappedUsers.Items.Add(item);
                }  
                sur.SecurityUserId = Convert.ToInt32(i.UserID);
                sur.SecurityRoleId = Convert.ToInt32(RoleID);
                MappedUser.Add(sur);
                Session["MappedUser"] = MappedUser;
                checkMappingButtons(listMappedUsers, listAllUsers);
                editUserUpdatePanel.Update();
            }
        }
