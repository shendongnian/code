    public class form_checkbox
    {
        public static List<string> RemoveExtraFalseFromCheckbox(List<string> val)
        {
            List<string> d_taxe1_list = new List<string>(val);
            int y = 0;
            foreach (string cbox in val)
            {
                if (val[y] == "false")
                {
                    if (y > 0)
                    {
                        if (val[y - 1] == "true")
                        {
                            d_taxe1_list[y] = "remove";
                        }
                    }
                }
                y++;
            }
            val = new List<string>(d_taxe1_list);
            foreach (var del in d_taxe1_list)
                if (del == "remove") val.Remove(del);
            return val;
        
        }      
    }
