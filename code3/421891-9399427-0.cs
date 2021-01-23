    using (FileStream infile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read))
    {
        using (StreamReader reader = new StreamReader(infile))
        {
            string recordIn = reader.ReadLine();
            while (recordIn != null)
            {
                fields = recordIn.Split(DELIM);
                stuff1.color = fields[0];
                stuff1.size = fields[1];
                stuff1.text = fields[2];
                if (fields[0] == "red")
                {
                    this.BackColor = System.Drawing.Color.Red;
                }
                if (fields[0] == "blue")
                {
                    this.BackColor = System.Drawing.Color.Blue;
                }
                if (fields[0] == "yellow")
                {
                    this.BackColor = System.Drawing.Color.Yellow;
                }
                if (fields[1] == "large")
                {
                    this.Size = new System.Drawing.Size(500, 500);
                }
                if (fields[1] == "small")
                {
                    this.Size = new System.Drawing.Size(300, 300);
                }
                this.Text = fields[2];
            }
        }
    }
