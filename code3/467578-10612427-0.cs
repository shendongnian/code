                try
                {
                    using (IsolatedStorageFile storagefile = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        if (storagefile.FileExists("NotesFile"))
                        {
                            using (IsolatedStorageFileStream fileStream = storagefile.OpenFile("NotesFile", FileMode.Open, FileAccess.ReadWrite))
                            {
                                StreamWriter writer = new StreamWriter(fileStream);
                                for (int i = 0; i < m_noteCount; i++)
                                {
                                    //writer.Write(m_arrNoteDate[i].ToShortDateString());
                                    writer.Write(m_arrNoteDate[i].ToString("d", CultureInfo.InvariantCulture));
                                    writer.Write(" ");
                                    writer.Write(m_arrNoteString[i]);
                                    writer.WriteLine("~`");
                                }
                                writer.Close();
                            }
                        }
