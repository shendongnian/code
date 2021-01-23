    private Dictionary<int, string> GetImageNames(ImageList imglist)
        {
            var dict = new Dictionary<int, string>();
            int salt = 0;
            foreach (var item in imglist.Images.Keys)
            {
                dict.Add(salt, item.ToString());
                salt++;
            }
            return dict;
        }
