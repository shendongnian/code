           static string[] Fn(string path, string Start, string End) {
            string[] vc = File.ReadAllLines(path);
            int nStart= Array.IndexOf(vc,Start);
            int nEnd =Array.IndexOf(vc,End);
           return vc.Skip(nStart).Take((nEnd+1) - nStart).ToArray<string>();
             }
