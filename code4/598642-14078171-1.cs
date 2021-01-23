            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < darray.Length; i++)
            {
                sb.Append("darray[i]["Sort_Order"].ToString());
                sb.Append(",");
            }
            if (darray.Length > 0)
                sb.Remove(sb.Length - 1, 1);
