    using System.IO;
    using System.IO.Compression;    // Add reference to System.IO.Compression
    ...
       
         private void button1_Click(object sender, EventArgs e) {
            var srcePath = @"c:\users\hpass_000\appdata\local\temp\example.zip";
            using (var file = new FileStream(srcePath, FileMode.Open)) {
                var zip = new ZipArchive(file, ZipArchiveMode.Read);
                var entry = zip.GetEntry("Chrysanthemum.jpg");
                var destPath = Path.GetTempFileName();
                using (var srce = entry.Open())
                using (var dest = new FileStream(destPath, FileMode.Create)) {
                    srce.CopyTo(dest);
                }
                using (var img = Image.FromFile(destPath)) {
                    this.BackgroundImage = new Bitmap(img);
                }
                File.Delete(destPath);
            }
        }
