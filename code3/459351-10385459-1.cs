    if (i == 0) return; // Cannot move up line 0
    string path = "c:\\temp\\myfile.txt";
    // get the lines
    string[] lines = File.ReadAllLines(path);
    if (lines.Length <= i) return; // You need at least i lines
    // Move the line i up by one
    string tmp = lines[i];
    lines[i] = lines[i-1];
    lines[i-1] = tmp;
    // Write the file back
    File.WriteAllLines(path, lines);
