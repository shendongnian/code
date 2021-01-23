private void ExtractResource(string resName, string fName)
 {
      object ob = Properties.Resources.ResourceManager.GetObject(resName, originalCulture);
      byte[] myResBytes = (byte[])ob;
      using (FileStream fsDst = new FileStream(fName, FileMode.CreateNew, FileAccess.Write))
      {
         byte[] bytes = myResBytes;
         fsDst.Write(bytes, 0, bytes.Length);
         fsDst.Close();
         fsDst.Dispose();
      }
}
