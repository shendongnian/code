    private void Form1_Load(object sender, EventArgs e)
            {
                listView1.VirtualMode = true; 		// switching virtual mode on
                listView1.VirtualListSize = 1000000000; 	// give it 1 million lines
            }
