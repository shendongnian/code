    internal Dictionary<string, string> _lfns = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    private static string GetLfnChunk(byte[] buffer)
    {
        // see http://home.teleport.com/~brainy/lfn.htm
        // NOTE: we assume ordinals are ok here.
        char[] chars = new char[13];
        chars[0] = (char)(256 * buffer[2] + buffer[1]);
        chars[1] = (char)(256 * buffer[4] + buffer[3]);
        chars[2] = (char)(256 * buffer[6] + buffer[5]);
        chars[3] = (char)(256 * buffer[8] + buffer[7]);
        chars[4] = (char)(256 * buffer[10] + buffer[9]);
        chars[5] = (char)(256 * buffer[15] + buffer[14]);
        chars[6] = (char)(256 * buffer[17] + buffer[16]);
        chars[7] = (char)(256 * buffer[19] + buffer[18]);
        chars[8] = (char)(256 * buffer[21] + buffer[20]);
        chars[9] = (char)(256 * buffer[23] + buffer[22]);
        chars[10] = (char)(256 * buffer[25] + buffer[24]);
        chars[11] = (char)(256 * buffer[29] + buffer[28]);
        chars[12] = (char)(256 * buffer[31] + buffer[30]);
        string chunk = new string(chars);
        int zero = chunk.IndexOf('\0');
        return zero >= 0 ? chunk.Substring(0, zero) : chunk;
    }
    private void LoadEntries()
    {
        _entries = new Dictionary<long, DirectoryEntry>();
        _freeEntries = new List<long>();
        _selfEntryLocation = -1;
        _parentEntryLocation = -1;
        string lfn = null;  //+++
        while (_dirStream.Position < _dirStream.Length)
        {
            long streamPos = _dirStream.Position;
            DirectoryEntry entry = new DirectoryEntry(_fileSystem.FatOptions, _dirStream);
            if (entry.Attributes == (FatAttributes.ReadOnly | FatAttributes.Hidden | FatAttributes.System | FatAttributes.VolumeId))
            {
                // Long File Name entry
                _dirStream.Position = streamPos;  //+++
                lfn = GetLfnChunk(Utilities.ReadFully(_dirStream, 32)) + lfn;  //+++
            }
            else if (entry.Name.IsDeleted())
            {
                // E5 = Free Entry
                _freeEntries.Add(streamPos);
                lfn = null; //+++
            }
            else if (entry.Name == FileName.SelfEntryName)
            {
                _selfEntry = entry;
                _selfEntryLocation = streamPos;
                lfn = null; //+++
            }
            else if (entry.Name == FileName.ParentEntryName)
            {
                _parentEntry = entry;
                _parentEntryLocation = streamPos;
                lfn = null; //+++
            }
            else if (entry.Name == FileName.Null)
            {
                // Free Entry, no more entries available
                _endOfEntries = streamPos;
                lfn = null; //+++
                break;
            }
            else
            {
                if (lfn != null) //+++
                { //+++
                    _lfns.Add(entry.Name.GetDisplayName(_fileSystem.FatOptions.FileNameEncoding), lfn); //+++
                } //+++
                _entries.Add(streamPos, entry);
                lfn = null; //+++
            }
        }
    }
