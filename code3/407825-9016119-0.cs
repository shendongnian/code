    public sealed class MySettings : ApplicationSettingsBase
    {
        public int GetSplitterPos(string splitterName)
        {
            return ((int)(this[splitterName]));
        }
        public void SetSplitterPos(string splitterName, int pos)
        {
            this[splitterName] = pos;
        }
    }
