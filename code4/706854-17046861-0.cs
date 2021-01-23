    public String returnCategories(string categories) 
        {
            string categoriesConc = "";
            string[] split = categories.Split(',');
            for (int i = 0; i < split.Length; i++) 
            {
                if (string.IsNullOrEmpty(categoriesConc))
                {
                    categoriesConc = split[i].ToString();
                }
                else 
                {
                    categoriesConc = categoriesConc + "," + split[i].ToString();
                }
            }
            return categoriesConc;
        }
