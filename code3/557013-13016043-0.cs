            string infile = @"C:\temp\in.dat";
            string outfile = @"C:\temp\out.dat";
            Regex re = new Regex(@"H[a-z]+ W[a-z]+");   // looking for "Hello World"
            string repl =  @"Hi there";
            Encoding ascii = Encoding.ASCII;
            byte[] inbytes = File.ReadAllBytes(infile);
            string instr = ascii.GetString(inbytes);
            Match match = re.Match(instr);
            int beg = 0;
            bool replaced = false;
            List<byte> newbytes = new List<byte>();
            while (match.Success)
            {
                replaced = true;
                for (int i = beg; i < match.Index; i++)
                    newbytes.Add(inbytes[i]);
                foreach (char c in repl)
                    newbytes.Add(Convert.ToByte(c));
                Match nmatch = match.NextMatch();
                int end = (nmatch.Success) ? nmatch.Index : inbytes.Length;
                for (int i = match.Index + match.Length; i < end; i++)
                    newbytes.Add(inbytes[i]);
                beg = end;
                match = nmatch;
            }
            if (replaced)
            {
                var newarr = newbytes.ToArray();
                File.WriteAllBytes(outfile, newarr);
            }
            else
            {
                File.WriteAllBytes(outfile, inbytes);
            }
