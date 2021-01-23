    public static string hashCalculator(string username, string password)//Use username as salt.
            {
                byte[] stringbytes = System.Text.Encoding.Unicode.GetBytes(username.ToLower() + password);
                return Convert.ToBase64String(new SHA384Managed().ComputeHash(stringbytes));
            }
