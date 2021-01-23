    var collectionSynchronizer = new CollectionSynchronizer<string, ContentImageEntity>
                {
                    CompareFunc = (communityImage, contentImage) => communityImage == contentImage.Name,
                    AddAction = sourceItem =>
                    {
                        var contentEntityImage = _contentImageProvider.Create(sourceItem);
                        contentEntityImages.Add(contentEntityImage);
                    },
                    UpdateAction = (communityImage, contentImage) =>
                    {
                        _contentImageProvider.Update(contentImage);
                    },
                    RemoveAction = contentImage =>
                    {
                        contentEntityImages.Remove(contentImage);
                    }
                };
                
                collectionSynchronizer.Synchronizer(externalContentImages, contentEntityImages);
