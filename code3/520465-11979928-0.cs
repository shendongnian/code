    while (br.BaseStream.Position < length)
    {
        // 3.
        // Read integer.
        int v = br.ReadInt32();
        textBox1.Text = v.ToString();
    }
