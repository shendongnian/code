    public static class Extensions
    {
        public static List<string> GetSelectedItems(this CheckBoxList cbl)
        {
            var result = new List<string>();
    
            foreach (ListItem item in cbl.Items)
                if (item.Selected)
                    result.Add(item.Value);
    
            return result;
        }
    }
