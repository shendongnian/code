        for (int i = 0; i < list.Count; i++ )
        {
            var val = list[i];
            int first = list.IndexOf(val), last;
            while ((last = list.LastIndexOf(val)) != first)
            {
                list.RemoveAt(last);
            }
        }
