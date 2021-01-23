                    while (sum < fileSize)
                    {
                        if (network.DataAvailable)
                        {
                            count = network.Read(data, 0, data.Length);
                            fs.Write(data, 0, count);
                            sum += count;
                        }
                    }
