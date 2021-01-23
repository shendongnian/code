    private string hex2dec(string hexString)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(long.Parse(hexString, System.Globalization.NumberStyles.HexNumber));
        return sb.ToString();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        int numRecords = 3737;
        int itemSectionStart = 0x00000008;
        int itemSectionEnd = 0x002e11ec;
        using (FileStream str = File.OpenRead("C:\\Users\\xxx\\Desktop\\xxx\\xxx\\xxx.dec"))
        {
            BinaryReader breader = new BinaryReader(str);
            breader.BaseStream.Position = itemSectionStart;
            byte[] itemSection = breader.ReadBytes(itemSectionEnd);
            int j = 0;
            int k = j++;
            for (int i = 0; i < numRecords; i++)
            {
                string id = BitConverter.ToString(itemSection, 808 * k++, 7);
                string[] strArrayID = id.Split(new char[] { '-' });
                string reversedID = strArrayID[6] + strArrayID[5] + strArrayID[4] + strArrayID[3] + strArrayID[2] + strArrayID[1] + strArrayID[0];
                listBox1.Items.Add(this.hex2dec(reversedID));
            }
        }
    }
