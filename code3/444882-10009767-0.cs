    foreach (string s1 in list)
                {
                    if (s1 != string.Empty)
                    {
                        dvProducts.RowFilter = "(CODE like '" + serachText + "*') AND (CODE <> '" + s1 + "')";
                        Session["ListViewItems"] = dvProducts;
     ListView1.Items.Add(dvProducts["Column Name"].toString());
                    }
                }
