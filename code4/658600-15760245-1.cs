     private async void AssignLocalFile()
        {
            m_StorageFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("VakantieApplicatie", CreationCollisionOption.OpenIfExists);
            m_StorageFile1 = await m_StorageFolder.CreateFileAsync(m_Name.Replace(" ", "_") + "1.log",
                                                                                    CreationCollisionOption.OpenIfExists);
            m_StorageFile2 = await m_StorageFolder.CreateFileAsync(m_Name.Replace(" ", "_") + "2.log",
                                                                                    CreationCollisionOption.OpenIfExists);
        }
