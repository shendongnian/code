    // Writing to the files
    using (var sw1 = new StreamWriter("DataNames.txt")) {
        sw1.WriteLine(textBox1.Text);
    }
    using(var sw2 = new StreamWriter("DataNumbers.txt")) {
        sw2.WriteLine(textBox2.Text);
    }
    // Reading from the files
    FileInfo file1 = new FileInfo("DataNames.txt");
    using (StreamReader sr1 = file1.OpenText()) {
        while (!sr1.EndOfStream) {
            listBox1.Items.Add(sr1.ReadLine());
        }
    }
    FileInfo file2 = new FileInfo("DataNumbers.txt");
    using (StreamReader sr2 = file2.OpenText()) {
        while (!sr2.EndOfStream)
        {
            listBox2.Items.Add(sr2.ReadLine());
        }
    }
