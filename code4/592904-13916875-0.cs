            string myString =
                     "db 4Dh, 5Ah, 80h, 00h, 01h, 00h, 00h, 00h, 04h, 00h, 10h, 00h, 0FFh, 0FFh, 00h, db 4Dh, 5Ah, 80h, 00h, 01h, 00h, 00h, 00h, 04h, 00h, 10h, 00h, 0FFh, 0FFh, 00h";
            
            StringBuilder sb = new StringBuilder();
            string[] splitString = myString.Split(',');
            for (int idx = 0; idx < splitString.Length; idx++)
            {
                sb.Append(splitString[idx] + ",");
                if (idx > 0 && idx%15 == 0)
                {
                    sb.Append('\n');
                }
            }
            string output = sb.ToString();
