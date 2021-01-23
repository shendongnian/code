                foreach (var item in nodes)
                {
                    var value =
                    nodes[0].Elements("script").ToList();
                    foreach (var items in value)
                    {
                        link += items.NextSibling.InnerText+ "\n";
                    }
                }
                MessageBox.Show(link);
            }
            else
                MessageBox.Show("no wordfound ");
