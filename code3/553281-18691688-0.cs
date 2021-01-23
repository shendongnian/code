    client.GetFileAsync("/novemberrain.mp3",
                    (response) =>
                    {
                        using (FileStream fs = new FileStream(@"D:\novemberrain.mp3", FileMode.Create))
                        {
                            for (int i = 0; i < response.RawBytes.Length; i++)
                            {
                                fs.WriteByte(response.RawBytes[i]);
                            }
                        }
                        MessageBox.Show("file downloaded");
                    },
                    (error) =>
                    {
                        MessageBox.Show("error downloading");
                    });
