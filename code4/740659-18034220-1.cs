                        var tagInDb = context.ProductTags.Local
                            .SingleOrDefault(t => t.Id == tag.Id);
                        if (tagInDb == null) {
                            tagInDb = tag;
                            context.ProductTags.Attach(tagInDb);
                        }
                        productInDb.ProductTags.Add(tagInDb);
