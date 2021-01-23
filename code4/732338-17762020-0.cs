    List<object> lstobj;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int t = listBoxNew.Items.Count();
            lstobj = new List<object>();
            TextBox obj = new TextBox();
            int p = 0;
            for (int i = 0; i < t; i++)
            {
                if(listBoxNew.Items[i].GetType()==obj.GetType())
                {
                    if (p == 0)
                    {
                        p = 1;
                        continue;
                    }
                    else
                    {
                        lstobj.Add(listBoxNew.Items[i]);
                    }
                }
            }
        }
