    public string FindMusicByID(int musicID)
        {
            var pathh= from plik in _data.musicMusicTables
                        where plik.musicMusicID == musicID
                        select new PathToFile { PathFile = plik.musicMusicPath };
    var cd = new System.Net.Mime.ContentDisposition {
    				FileName = "filename",
    				Inline = false
    			};
    Response.AppendHeader("Content-Disposition", cd.ToString());
                return File(path, asset.AssetType.MimeType); 
            }
