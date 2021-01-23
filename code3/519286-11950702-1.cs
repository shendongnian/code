    Nav n = navDB.Navs.Where(row => 
            {
                int i = 0;
                if (int.TryParse(Request.Form["ID"].ToString(), out i)
                {
                    if(row.ID == i)
                     return true;
                }
                return false;
            }).FirstorDefault();
