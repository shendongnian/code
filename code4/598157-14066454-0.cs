       string[] BundleItemID = form.GetValues("txtbundleid");
        for (int i = 0; i < skuid.Length; i++)
        {
            ProductBundleItem productbundleitem = new ProductBundleItem();
            if (!string.IsNullOrEmpty(BundleItemID[i]))
            {
                long val = 0;
                if (!long.TryParse(BundleItemID[i], out val))
                {
                    MessageBox.Show(string.Format("{0} is not a valid Int64 value", BundleItemID[i]));
                    break;
                }
                productbundleitem.BundleItemId = val;
            }
        }
