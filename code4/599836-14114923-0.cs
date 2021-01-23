    using System.IO;
    (client.GetList(new Uri(url), out contents);
    foreach (SvnListEventArgs item in contents)
    {
        //FileInfo object and get the Length.
	  FileInfo fi = new FileInfo(item);
	  long fileLength = fi.Length;
    }
