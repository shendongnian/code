    var source = new List<MediaFolder>
                {
                    new MediaFolder
                        {
                            Id = "Id1",
                            Name = "Name1",
                            Path = "Path1"
                        },
                    new MediaFolder
                        {
                            Id = "Id2",
                            Name = "Name2",
                            Path = "Path2"
                        },
                    new MediaFolder
                        {
                            Id = "Id3",
                            Name = "Name3",
                            Path = "Path3"
                        },
                    new MediaFolder
                        {
                            Id = "Id4",
                            Name = "Name4",
                            Path = "Path4"
                        },
                    new MediaFolder
                        {
                            Id = "Id5",
                            Name = "Name5",
                            Path = "Path5"
                        },
                    new MediaFolder
                        {
                            Id = "Id6",
                            Name = "Name6",
                            Path = "Path6"
                        }
                };
            var target = new List<MediaFolder>
                {
                    new MediaFolder
                        {
                            Id = "Id1",
                            Name = "Actualizado en el objeto",
                            Path = "Path1"
                        },
                        //Id2 eliminado
                    new MediaFolder
                        {
                            Id = "Id3",
                            Name = "Name3",
                            Path = "Actualizado tambien"
                        },
                    new MediaFolder
                        {
                            Id = "Id4",
                            Name = "Name4",
                            Path = "Path4"
                        },
                    new MediaFolder
                        {
                            Id = "Id5",
                            Name = "Name5",
                            Path = "Path5"
                        },
                    new MediaFolder
                        {
                            Id = "Id6",
                            Name = "Name6",
                            Path = "Path6"
                        },
                         new MediaFolder
                        {
                            Id = "Id7",
                            Name = "Nuevo Item 7",
                            Path = "Nuevo Item 7"
                        }
                };
            var merge = source.Merge(target, (x, y) => x.Id == y.Id);
            var toUpdate = merge.Matched((x, y) => x.Name != y.Name | x.Path != y.Path)
                .ToArray();
            var toDelete = merge.NotMatchedBySource();
            var toInsert = merge.NotMatchedByTarget();
            Assert.AreEqual(2, toUpdate.Count());
            Assert.IsTrue(toUpdate.Count(x => x.Source.Id == "Id1" & x.Target.Id == "Id1") > 0);
            Assert.IsTrue(toUpdate.Count(x => x.Source.Id == "Id3" & x.Target.Id == "Id3") > 0);
            Assert.AreEqual("Id7", toInsert.First().Id);
            Assert.AreEqual("Id2", toDelete.First().Id);
