    bool eventHandled = false;
    private void lv_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        if (!eventHandled)
        {
            eventHandled = true;
            if (e.IsSelected)
            {
                Debug.WriteLine("Index: " + lv.SelectedIndices[0].ToString());
                if (lv.Tag != null)
                {
                    if ((int)lv.Tag != lv.SelectedIndices[0])
                    {
                        if (!UserClosedSession())
                        {
                            //lv.ItemSelectionChanged -= new ListViewItemSelectionChangedEventHandler(lv_ItemSelectionChanged);
                            //lv.ItemSelectionChanged -= lv_ItemSelectionChanged;
                            lv.Items[(int)lv.Tag].Selected = true;
                            //lv.ItemSelectionChanged +=new ListViewItemSelectionChangedEventHandler(lv_ItemSelectionChanged);
                            return;
                        }
                    }
                }
                else
                    lv.Tag = lv.SelectedIndices[0];
            }
        }
        else
            eventHandled = false;
    }
