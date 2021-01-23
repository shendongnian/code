    stringSeparators = new string[] { token + start_key };
    transfer = s.Split(stringSeparators, 2, StringSplitOptions.None)[1];
    if (!string.IsNullOrEmpty(transfer))
    {
        string key = "";
        string[] split = transfer.Split(' ');
        if (split[0] == start_key)
        {
            for (int i = 0; i < key_length; i++)
            {
                key += split[i + Convert.ToInt32(key_index)];
            }
            RX_TX_Handle(key, token);
        }
    }
