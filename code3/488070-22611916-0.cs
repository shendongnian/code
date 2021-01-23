    private string GetTagsList()
        {
            string Tags = string.Empty;
            if (lstTags.SelectedItems.Count >= 0)
            {
                for (int i = 0; i < lstTags.SelectedItems.Count; i++)
                {
                    Tags += lstTags.SelectedIndices[i].ToString() + ",";
                }
                Tags = Tags.Trim(',');
            }
            return Tags;
        }
