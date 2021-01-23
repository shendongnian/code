    using System.Security.Cryptography;
    ...
    
    private RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();
    
    private int NextInt32(int maxValue)
    {
        byte[] intBytes = new byte[4];
        rnd.GetBytes(intBytes);
        return Math.Abs(BitConverter.ToInt32(intBytes, 0)) % maxValue + 1;
    }
    
    // And your method with textBox
    private void button5_Click(object sender, EventArgs e)
    {
        textBox.Text = NextInt32(1000).ToString(); 
    }
