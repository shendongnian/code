    private void write()
        {
            string[] lines = new string[first.Length];
            for (int i = 0; i < lines.Length; i++)
                if (bDay[i].ToString(format) != "1/1/0001")
                    lines[i] = first[i] + ',' + last[i] + ',' + bDay[i].ToString(format);
            lines = lines.Where(s => s != null).ToArray();
            txtbxNames.Clear();
            txtbxNames.Lines = lines;
        }
