    var fileEntries = Directory.GetFiles(Application.StartupPath + "/TrainedFaces/", "*.bmp", SearchOption.AllDirectories)
                               .Select(f=>new FileInfo(f))
                               .OrderNaturallyBy(fi=>fi.Name)
                               .Select(fi=>fi.FullName);
    public static class S_O_Extensions
    {
        public static IEnumerable<T> OrderNaturallyBy<T>(this IEnumerable<T> list, Func<T,string> selector)
        {
            return list.Select(item => new
                        {
                            t = item,
                            tempstr = Regex.Replace(selector(item), @"\d+", m => m.Value.PadLeft(20, '0'))
                        })
                        .OrderBy(x => x.tempstr)
                        .Select(x => x.t);
        }
    }
