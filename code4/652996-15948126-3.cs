    XDocument xmlDoc = XDocument.Parse(dataInXmlFile);
                var query = from l in xmlDoc.Descendants("Category")
                            select new Notch
                            {
                                name = (string)l.Attribute("name").Value,
                                Titles = l.Element("Articles").Elements("article")
                                         .Select(s => s.Attribute("title").Value)
                                         .ToList(),
                                Articles = l.Element("Articles").Elements("article")
                                            .Select(article =>  new NotchSubItem
                                            {
                                            Image = article.Element("thumb_image").Element("image").Attribute("url").Value,
                                            ArticleId = article.Attribute("articleid").Value,
                                            FullContent = article.Element("FullContent").Value.ToString(),
                                            Titles = article.Attribute("title").Value,
                                            })
                                            .ToList(),
                                Images = l.Element("Articles").Elements("article").Elements("thumb_image").Elements("image")
                                         .Select(x => x.Attribute("url").Value).ToList(),
                            };
							
							foreach (var result in query)
							{
								Console.WriteLine(result.name);
								foreach (var detail in result.Titles.Zip(result.Images, (st, si) => string.Format("{0} {1}", st, si)))
								{
									Console.WriteLine(detail);
                                   
								}
                             
							}
							NotchsList11.ItemsSource = query;
			}
			catch(Exception e)
			{
				MessageBox.Show("Binding Failed");
			}
