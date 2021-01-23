            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < darray.Length; i++)
            {
                sb.Append(darray[i]["Sort_Order"].ToString());
                if (i < (darray.Length - 1))
                {
                    sb.Append(",");
                }
            }
