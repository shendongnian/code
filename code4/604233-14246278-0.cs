    StreamReader sr1 = file1.OpenText();
    try {
                while (!sr1.EndOfStream)
                {
                    listBox1.Items.Add(sr1.ReadLine());
                }
    }
    finally { 
      sr1.Close();
    }
                FileInfo file2 = new FileInfo("DataNumbers.txt");
                StreamReader sr2 = file2.OpenText();
    try {
                while (!sr2.EndOfStream)
                {
                    listBox2.Items.Add(sr2.ReadLine());
                }
    }
    finally {
      sr2.Close();
    }
