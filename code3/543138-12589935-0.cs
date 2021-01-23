    private void Openbtn_Click(object sender, EventArgs e)
    {
        textBox1.Text = "";
        listView1.Items.Clear();
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Title = "Open GSMB File";
        ofd.Filter = "GSMB Files (*.gsmb)|*.gsmb|All Files (*.*)|*.*";
        if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
			try {
				MessageBox.Show("File opened Succesfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
				path = ofd.FileName;
				BinaryReader br = new BinaryReader(File.OpenRead(path), Encoding.Unicode);
				BinaryReader brs = new BinaryReader(File.OpenRead(path), Encoding.Unicode);
				brs.BaseStream.Position = 0x4;
				menuItem9.Text = brs.ReadInt32().ToString();
				if (menuItem9.Text == "3620")
				{
					num_pointers = 204;
					menuItem8.Text = num_pointers.ToString();
				}
				else if (menuItem9.Text == "54662")
				{
					num_pointers = 2372;
					menuItem8.Text = num_pointers.ToString();
				}
				else if (menuItem9.Text == "9560")
				{
					num_pointers = 88;
					menuItem8.Text = num_pointers.ToString();
				}
				else if (menuItem9.Text == "1126")
				{
					num_pointers = 130;
					menuItem8.Text = num_pointers.ToString();
				}
				else if (menuItem9.Text == "342")
				{
					num_pointers = 16;
					menuItem8.Text = num_pointers.ToString();
				}
				else if (menuItem9.Text == "6232")
				{
					num_pointers = 467;
					menuItem8.Text = num_pointers.ToString();
				}
				else if (menuItem9.Text == "75698")
				{
					num_pointers = 498;
					menuItem8.Text = num_pointers.ToString();
				}
				else if (menuItem9.Text == "9914")
				{
					num_pointers = 110;
					menuItem8.Text = num_pointers.ToString();
				}
				else if (menuItem9.Text == "128")
				{
					num_pointers = 4;
					menuItem8.Text = num_pointers.ToString();
				}
				else if (menuItem9.Text == "5394")
				{
					num_pointers = 156;
					menuItem8.Text = num_pointers.ToString();
				}
				else if (menuItem9.Text == "12000")
				{
					num_pointers = 580;
					menuItem8.Text = num_pointers.ToString();
				}
				else 
				{
					MessageBox.Show("This is not a Pokémon Typing Adventure string file !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				List<int> offsets = new List<int>();
				int startstr = 0x1C;
				br.BaseStream.Position = startstr;
				int startstrval = br.ReadInt32();
				for (int i = 4; i < (num_pointers * 4 + 1); i += 4)
				{
					br.BaseStream.Position = startstr + i;
					offsets.Add(br.ReadInt32() + startstrval);
				}
				Dictionary<int, string> values = new Dictionary<int, string>();
				for (int i = 0; i < offsets.Count; i++)
				{
					int currentOffset = offsets[i];
					int nextOffset = (i + 1) < offsets.Count ? offsets[i + 1] : (int)br.BaseStream.Length;
					int stringLength = (nextOffset - currentOffset - 1) / 2;
					br.BaseStream.Position = currentOffset;
					var chars = br.ReadChars(stringLength);
					values.Add(currentOffset, new String(chars));
				}
				foreach (int offset in offsets)
				{
					listView1.Items.Add(offset.ToString("X")).SubItems.Add(values[offset]);
				 listView1.Items[offset].SubItems[1].Text.Replace(System.Environment.NewLine, "\n");
				}				
			}
			finally {
				br.Close();
				br = null;
			}
        }
        ofd.Dispose();
        ofd = null;
    }
    private void menuItem10_Click(object sender, EventArgs e)
        {
		BinaryWriter bw;
		try {
			bw = new BinaryWriter(File.OpenWrite(path));
			bw.BaseStream.Position = 0x20;
			int number_pointers = Convert.ToInt32(num_pointers);
			Encoding enc = Encoding.Unicode;
			bw.Write(number_pointers);
			int curr_pointer = 4 + number_pointers * 4;
			for (int i = 0; i < number_pointers; i++)
			{
				bw.Write(curr_pointer);
				curr_pointer += enc.GetByteCount(listView1.Items[i].SubItems[1].Text) + 2;
			}
			for (int i = 0; i < number_pointers; i++)
				bw.Write(enc.GetBytes(listView1.Items[i].SubItems[1].Text + '\0'));
		}
		finally {
			bw.Flush();
			bw.Close();
			bw = null;
		}
    }
