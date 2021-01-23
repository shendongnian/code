            using (var w = new StreamWriter(keywords_path_file))
            {
                if (FormIsClosing == true)
                {
                crawlLocaly1 = new CrawlLocaly(this);
                crawlLocaly1.StartPosition = FormStartPosition.CenterParent;
                DialogResult dr = crawlLocaly1.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    if (LocalyKeyWords.ContainsKey(mainUrl))
                    {
                        LocalyKeyWords[mainUrl].Clear();
                        LocalyKeyWords[mainUrl].Add(crawlLocaly1.getText());
                    }
                    else
                    {
                        LocalyKeyWords[mainUrl] = new List<string>();
                        LocalyKeyWords[mainUrl].Add(crawlLocaly1.getText());
                    }
                    Write(w);
                    ClearListBox();
                }
                if (dr == DialogResult.Cancel)
                {
                    Write(w);
                }
                }
            }
