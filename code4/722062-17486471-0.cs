    private void PrepareStatusString(List<SmsResponse> responseList)
    {
        bool isfirst = true;
        StringBulder sb = new StringBuilder();
        foreach (var item in responseList)
        {
            if (item.Response != 0)
            {
                if(isfirst)
                    sb.AppendFormat("{0}|{1}|{2}", item.AliasName, item.CellPhoneNumber,item.Response.ToString());
                else
                    sb.AppendFormat(",{0}|{1}|{2}", item.AliasName, item.CellPhoneNumber, item.Response.ToString());
                isfirst = false;
            }
        }
        StatusDescription = sb.ToString();
    }
