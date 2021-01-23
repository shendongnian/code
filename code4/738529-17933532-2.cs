    public void SaveTo(string file)
            {
                NbtFile nbt;
                if( File.Exists( file ) )
                {
                  nbt = new NbtFile(file);
                }
                else
                {
                  nbt = new NbtFile();
                }
                nbt.RootTag = new NbtCompound("");
                var list = new NbtList("servers", NbtTagType.Compound);
                foreach (var server in Servers)
                {
                    var compound = new NbtCompound();
                    compound.Add(new NbtString("name", server.Name));
                    compound.Add(new NbtString("ip", server.Ip));
                    compound.Add(new NbtByte("hideAddress", (byte)(server.HideAddress ? 1 : 0)));
                    compound.Add(new NbtByte("acceptTextures", (byte)(server.AcceptTextures ? 1 : 0)));
                    list.Add(compound);
                }
                nbt.RootTag.Add(list);
                nbt.SaveToFile(file, NbtCompression.None);
            }
