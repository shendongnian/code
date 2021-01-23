    IRandomAccessStream sessionRandomAccessFile1 = await this.m_StorageFile1.OpenAsync(FileAccessMode.Read);
                    IRandomAccessStream sessionRandomAccessFile2 = await this.m_StorageFile2.OpenAsync(FileAccessMode.Read);
                    if (sessionRandomAccessFile1.Size == 0)
                    {
                        await FileIO.AppendLinesAsync(m_StorageFile1, lines);
                    }
                    else if (sessionRandomAccessFile1.Size < 5000000)
                    {
                        if (sessionRandomAccessFile1.Size > 4999900 )
                        {
                            await m_StorageFile2.DeleteAsync();
                            AssignLocalFile();
                        }
                        await FileIO.AppendLinesAsync(m_StorageFile1, lines);
                        
                    }
                    else if (sessionRandomAccessFile2.Size < 5000000)
                    {
                        if (sessionRandomAccessFile1.Size > 5000000 && sessionRandomAccessFile2.Size > 4999900)
                        {
                            await m_StorageFile1.DeleteAsync();
                            AssignLocalFile();
                        }
                        await FileIO.AppendLinesAsync(m_StorageFile2, lines);
                        
                    }
