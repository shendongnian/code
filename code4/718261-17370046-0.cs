            private void GetList(List<string> lst)
            {
                List<string> NewList = lst.Cast<string>().ToList();
                NewList.Add("6");
                //not same values.
                //or....
                List<string> NewList = lst.ConvertAll(s => s);
                NewList.Add("6");
                //again different values
                
            }
