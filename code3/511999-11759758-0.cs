    public void SaveAs(string filename) {
         HttpPostedFile f = PostedFile;
         if (f != null) {
              f.SaveAs(filename);
         }
    }
