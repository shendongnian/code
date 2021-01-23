     public static string generateCode()
            {          
                string chrs = "abcdefghijklmnopqrstuvwxyz";
                char[] arr = chrs.ToCharArray();
                string code = "";
                for (int i = 0; i < 5; i++)
                {
                    code += arr[r.Next(arr.Count())];
                }
                return code;
            }
