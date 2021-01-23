     private void imageClicked(Object sender, System.EventArgs e)
        {
            if(listView1.SelectedItems.Count < 1)
                    return;
            ListViewItem selectedItem = listView1.SelectedItems[0];
            selectedFBId = selectedItem.Tag as string;
            selectedFBName = selectedItem.Text;
            DialogResult dialogA = MessageBox.Show("Analyse employee data?", "SOC", MessageBoxButtons.YesNo);
            if (dialogA == DialogResult.Yes)
            {
                TargetEmployee.Text = "Selected Target: " + selectedFBName;
                pf.Show();
                ThreadPool.QueueUserWorkItem(LoadUserDetails);
            }
        }
