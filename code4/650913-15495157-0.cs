       FileSpec fso = new FileSpec(FileSpec.DepotSpec(fsd.depotPath).DepotPath, Revision.Head);
                            IList<FileSpec> fsos = new List<FileSpec>();
                            fsos.Add(fso);
                            Options opts = new Options(); opts.Add("-a", "");
                            IList<FileAnnotation> fas = rep.GetFileAnnotations(fsos, opts);
                            foreach (FileAnnotation fa in fas)
                            {
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                lines5+= fa.Line;
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
