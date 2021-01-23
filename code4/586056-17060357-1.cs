    public sealed class Commentary : MarshalByRefObject {
        // Fields
        private readonly dynamic _commentary;
        // Methods
        internal Commentary(dynamic commentary) {
            _commentary = commentary;
        }
        public void Apply() {
            _commentary.Apply();
        }
        public void Close() {
            _commentary.Close();
        }
        public bool LoadFormula(string path) {
            return _commentary.LoadFormula(path);
        }
        public bool Save(string path) {
            return _commentary.Save(path);
        }
        public bool SaveFormula(string path) {
            return _commentary.SaveFormula(path);
        }
    }
