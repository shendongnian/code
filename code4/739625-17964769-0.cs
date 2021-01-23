    private static void UpdateFile(int selected)
        {
            var lines = File.ReadAllLines("test.csv");
            lines[selected] = (Convert.ToInt32(lines[selected]) + 1).ToString();
            File.WriteAllLines("test.csv", lines);
        }
