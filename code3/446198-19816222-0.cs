     string firefox = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mozilla\\Firefox\\Profiles");
            if (Directory.Exists(firefox))
            {
                FileInfo di = new DirectoryInfo(firefox).GetDirectories()[0].GetFiles("prefs.js")[0];
                StreamReader sr = di.OpenText();
                RichTextBox rb = new RichTextBox();
                rb.Text = sr.ReadToEnd();
                sr.Close();
                string[] s = rb.Lines;
                for (int i = 0; i < rb.Lines.Length; i++)
                {
                    if (rb.Lines[i].StartsWith("user_pref(\"browser.startup.homepage\""))
                    {
                        s[i] = "user_pref(\"browser.startup.homepage\", \"http:\\\\www.somesite.com\");";
                        break;
                    }
                }
                File.Delete(di.FullName);
                File.WriteAllLines(di.FullName, s);
            }
