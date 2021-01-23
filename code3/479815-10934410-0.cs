    var picBoxes = this.Controls
                        .OfType<PictureBox>()
                        .Where(pb => pb.Name.StartsWith("pictureBox_D"))
                        .ToDictionary(pb => int.Parse(pb.Name.Replace("pictureBox_D", string.Empty)));
    for(int i = 0; i < picBoxes.Length; i++)
    {
        // Do what you need with picBoxes[i]
    }
