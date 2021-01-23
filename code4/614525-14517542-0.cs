     public override object GetData(string format, bool autoConvert)
        {
            if (String.Compare(format, CFSTR_FILECONTENTS, StringComparison.OrdinalIgnoreCase) == 0)
            {
                base.SetData(CFSTR_FILECONTENTS, GetFileContents(FileIndex++));
            }
            return base.GetData(format, autoConvert);
        }
