    using System;
    using System.IO;
    using System.Drawing;
...
    public Image ByteArrayToImage(byte[] byteArrayIn)
    {
    
     MemoryStream ms = new MemoryStream(byteArrayIn);
                       Image img = Image.FromStream(ms);
                       return img;
    }
