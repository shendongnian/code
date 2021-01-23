    public static bool PostImg(Frm form, string AccessToken, string Status, string ImagePath )
    {
        try
        {
            if (form.listBox2.SelectedItems.Count  > 0)
            {
                string item;
                foreach (int i in form.listBox2.SelectedIndices)
                {
                    item = form.listBox2.Items[i].ToString();
                    groupid = item;
                    FacebookClient fbpost = new FacebookClient(AccessToken);
                    var imgstream = File.OpenRead(ImagePath);
                    dynamic res = fbpost.Post("/" + groupid + "/photos", new
                   {
                       message = Status,
                       File = new FacebookMediaStream
                       {
                           ContentType = "image/jpg",
                           FileName = Path.GetFileName(ImagePath)
                       }.SetValue(imgstream)
                   });
                    result = true;
                }
            }
            return result;
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);
            return false;
        }
    }
