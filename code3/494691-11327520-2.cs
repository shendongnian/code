 private void ProcessTextLength(string story)
        {
            string storytext = story.Replace("\n\n", "\n\n^");
            List<string> storylist = storytext.Split('^').ToList();
            List<string> finalstorylist = new List<string>();
            string currenttext = "";
            foreach (var item in storylist)
            {
                currenttext = this.StorytextBlock.Text;
                this.StorytextBlock.Text = this.StorytextBlock.Text + item;
                if(this.StorytextBlock.ActualHeight > 2048)
                {
                    finalstorylist.Add(currenttext);
                    this.StorytextBlock.Text = item;
                }
                if (storylist.IndexOf(item) == storylist.Count - 1)
                {
                    finalstorylist.Add(this.StorytextBlock.Text);
                }
            }
            this.StorytextBlock.Text = "";
            foreach (var finalitem in finalstorylist)
            {
                string text = finalitem;
                if (text.StartsWith("\n\n"))
                    text = text.Substring(2);
                if (text.EndsWith("\n\n"))
                    text = text.Remove(text.Length - 2);
                this.textBlockStackPanel.Children.Add(new TextBlock
                                                          {
                                                              MaxHeight = 2048,
                                                              TextWrapping = TextWrapping.Wrap,
                                                              FontSize = 24,
                                                              TextTrimming = TextTrimming.WordEllipsis,
                                                              FontFamily = new FontFamily("Segoe WP"),
                                                              Text = text,
                                                              Foreground = new SolidColorBrush(Color.FromArgb(255,70,70,70))                                                             
                                                          });                
            }       
        }
