    var dir = new System.IO.DirectoryInfo(imagePath);
    List<FileInfo> images = dir.GetFiles("*.jpg", System.IO.SearchOption.AllDirectories).ToList();
    List<PictureBox> pictures = new List<PictureBox>();
    foreach (FileInfo img in images) {
    	PictureBox picture = new PictureBox();
    	picture.Image = Image.FromFile(img.FullName);
    	pictures.Add(picture);
    }
