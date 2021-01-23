    MyResult result = GetResult();
                    using (IndexWriter indexWriter = Initialize())
                    {
                        var document = new Document();
                        document.Add(new Field("ID", result.ID.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZE));
                        foreach (string item in result.MyList)
                        {
                            document.Add(new Field("mylist", item, Field.Store.YES, Field.Index.NOT_ANALYZE));
                        }
                        indexWriter.AddDocument(document);
                    }
