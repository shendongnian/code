    static class CheckedListBoxHelper
    {
        public static void SetChecked(this CheckedListBox list, string value)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].Equals(value))
                {
                    list.SetItemChecked(i, true);
                    break;
                }
            }
        }
    }
 
