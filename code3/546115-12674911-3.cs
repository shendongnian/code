    int index = list.FindIndex(s => s.EndsWith("/test5\""));
    // Or whatever test is appropriate.
    if (index >= 0) {
        list.RemoveAt(index);
        File.WriteAllLines(filename, list.ToArray());
    }
