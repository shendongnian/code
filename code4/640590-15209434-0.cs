    Dictionary<string, int> conversionLookup = new Dictionary<string, int>();
    for (int i = 0; i < dtConversion.Rows.Count; ++j)
    {
        conversionLookup.Add(string.Format("{0}:{1}", 
            dtConversion.Rows[j]["vend_contract_no"].ToString(),
            dtConversion.Rows[j]["vend_item_id"].ToString()), j);
    }
