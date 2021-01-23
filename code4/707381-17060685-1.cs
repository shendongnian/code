            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@"C:\SomeFolder\");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (System.IO.FileInfo fi in di.GetFiles())
            {
                using (System.IO.StreamReader reader = fi.OpenText())
                {
                    sb.AppendLine(reader.ReadToEnd());
                }
            }
