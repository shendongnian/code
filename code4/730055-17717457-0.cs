    j = htmlDoc.DocumentNode.SelectNodes("//tr").Count;
                        if (j != 0)
                        {
                            for (int i = 2; i < j; ++i)
                            {
                                for (int k = 1; k < 3; k++)
                                {
                                    HtmlNodeCollection row = htmlDoc.DocumentNode.SelectNodes("/html/body/table/tr[" + i + "]/td[" + k + "]");
                                    Console.WriteLine("nb or row" + row.Count);
                                    Console.WriteLine(row[0].InnerText);
                                    //Console.Read(); 
                                }
                            }
                        }
