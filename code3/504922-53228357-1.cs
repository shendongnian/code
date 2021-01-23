    var collectionSynchronizer = new CollectionSynchronizer<string, ContentImageEntity>
                {
                    CompareFunc = (communityImage, contentImage) => communityImage == contentImage.Name,
                    AddAction = sourceItem =>
                    {
                        var contentEntityImage = _contentImageProvider.Create(sourceItem);
                        contentEntityImages.Add(contentEntityImage);
                        _unitOfWorkCore.AddForSave(contentEntityImage, true);
                    },
                    UpdateAction = (communityImage, contentImage) =>
                    {
                        _contentImageProvider.Update(contentImage);
                        _unitOfWorkCore.AddForSave(contentImage, true);
                    },
                    RemoveAction = contentImage =>
                    {
                        contentEntityImages.Remove(contentImage);
                        _unitOfWorkCore.AddForDelete(contentImage);
                    }
                };
                
                collectionSynchronizer.Synchronizer(externalContentImages, contentEntityImages);
