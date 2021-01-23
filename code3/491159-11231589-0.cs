            StringBuilder sb = new StringBulder();
            for (int i = 0; i < blah.Count; i++)
            {
                sb.Append(blah[i].ToString());
                if (i % 5 == 0)
                {
                    sb.AppendLine();
                }
                else
                {
                    sb.Append(" ");
                }
            }
