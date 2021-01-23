        private bool WMPCodecCheck(string fileName)
        {
            try
            {
                WindowsMediaPlayer wmp = new WindowsMediaPlayer();
                wmp.mediaCollection.add(fileName);
                IWMPMedia currentWMV = wmp.newMedia(fileName);
                media = wmp.mediaCollection;
                this.codecType = media.getMediaAtom("FourCC");
                IWMPPlaylist mediaList = null;
                IWMPMedia mediaItem;
                mediaList = media.getByAttribute("MediaType", "Video");
                for (int i = 0; i < mediaList.count; i++)
                {
                    mediaItem = mediaList.get_Item(i);
                    if (mediaItem.sourceURL.Equals(fileName))
                    {
                        if (_hasCodec.Equals(GetCodec(mediaItem)))
                        {
                            //MessageBox.Show("Codec Exists!");
                            wmp.mediaCollection.remove(mediaItem, true);
                            return true;
                        }
                    }
                }
                wmp.mediaCollection.remove(currentWMV, true);
                return false;
            }
            catch (Exception e)
            {
                Log.LogToFile("Codec Read Error." + e, LogType.Exception);
            }
            return false;
        }
        private string GetCodec(IWMPMedia mediaItem)
        {
            // Has Codec = 877474375
            // No Codec  = 861293911
            string codec = mediaItem.getItemInfoByAtom(codecType);
            if (string.IsNullOrEmpty(codec))
            {
                codec = mediaItem.getItemInfoByAtom(codecType);
            }
            //MessageBox.Show("Codec Hex Value: " + codec);
            return codec;
        }
