     public DataTable RemoveDuplicateRows(DataTable OriginalLinks, DataTable UpdatedLinks) // OriginalLinks is a 1-col dt to delete from new dt
        {
    
            ArrayList arrOriginalLinks = new ArrayList();
    
            if (OriginalLinks.Rows.Count > 0)
            {
    
                foreach (DataRow dr in OriginalLinks.Rows)
                {
                    arrOriginalLinks.Add(dr["LinkName"]);
                }
            }
    
    
            if (OriginalLinks.Rows.Count == 0)
            {
                // do nothing
            }
            else
            {
                for (int i = OriginalLinks.Rows.Count - 1; i >= 0; i--)
                {
                    string filter = "LinkName='" + arrOriginalLinks[i].ToString() + "'";
    
                    UpdatedLinks.Select(filter).ToList().ForEach(r => r.Delete());
    
    
                }
        
            }
    
            return UpdatedLinks;
    
        }
