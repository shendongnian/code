    for (int i = 0; i < UPCList.Items.Count; i++)
            {
                if (UPCList.SelectedIndex == i)
                {
                    UPCList.Items.RemoveAt(i);
                }
            }
