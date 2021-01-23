     public static string ArrayToString2D(string[,] arr)
        {
            StringBuilder str = new StringBuilder();
            str.Append("[['");
            for (int k = 0; k < arr.GetLength(0); k++)
            {
                for (int l = 0; l < arr.GetLength(1); l++)
                {
                    if (arr[k, l] == null)
                        str.Append("','");
                    else
                        str.Append(arr[k, l].ToString() + "','");
                }
                str.Remove(str.Length - 2, 2);
                str.Append("],['");
            }
            str.Remove(str.Length - 4, 4);
            str.Append("]]");
            return str.ToString();
        }
