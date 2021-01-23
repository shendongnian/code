            private static string GetNewFileName(string dir)
            {
                Regex reg = new Regex(@"image(\d)+[.]");
    
                var list = Directory.GetFiles(dir, "*.png").Where(path => reg.IsMatch(path))
                         .ToList();
    
                if (list.Count == 0)
                    return "image1.png";
    
                var lastName =
                    list.Select(x => (new FileInfo(x)).Name.Replace("image", "").Replace(".png", "")).OrderBy(x => x).Last();
    
                return string.Format("image{0}.png", int.Parse(lastName)+1);
            }
;
