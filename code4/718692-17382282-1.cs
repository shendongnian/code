    private void Form1_Load(object sender, EventArgs e)
    {
        List<string> adress = new List<string>()
        {
            "http://i.telegraph.co.uk/multimedia/archive/02351/Jaguar-F-type-9_2351861k.jpg",
            "http://i.telegraph.co.uk/multimedia/archive/02351/Jaguar-F-type-5_2351885k.jpg",
            "http://i.telegraph.co.uk/multimedia/archive/02351/Jaguar-F-type-7_2351893k.jpg"
        };
        ImageList il = new ImageList();
        DownloadImagesFromWeb(address, il);
        il.ImageSize = new Size(32, 32);
        int count = 0;
        listView1.LargeImageList = il;
        List<string> names = new List<string>() { "1", "2", "3", "4" };
        foreach (string s in names)
        {
            ListViewItem lst = new ListViewItem();
            lst.Text = s;
            lst.ImageIndex = count++;
            listView1.Items.Add(lst);
        }
    }
    private void DownloadImagesFromWeb(List<string> adress, ImageList il)
    {
        foreach (string img in adress)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create(img);
            System.Net.WebResponse resp = request.GetResponse();
            System.IO.Stream respStream = resp.GetResponseStream();
            Bitmap bmp = new Bitmap(respStream);
            respStream.Dispose();
            
            il.Images.Add(bmp);
        }
    }
