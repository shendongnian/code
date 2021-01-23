    System.Collections.ArrayList searchArrayList = new System.Collections.ArrayList();
    searchArrayList.Add(new int[] { 1, 125, 1554 });
    foreach (int[] i in searchArrayList) {
        IEnumerable<string> findFiles = Directory.EnumerateFiles(@"c:\", "File*.txt", SearchOption.TopDirectoryOnly).Where(f => i.Contains(Convert.ToInt32(Regex.Match(f, @"\d+").Value)));
    }
