                using (await blogLock.LockAsync())
                {
                    using (var stream = await folder.OpenStreamForReadAsync(_blogFileName))
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var json = await reader.ReadToEndAsync();
                            var blog = await JsonConvert.DeserializeObjectAsync<Blog>(json);
                            return blog;
                        }
                    }
                }
