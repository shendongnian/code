    public struct LocalAbsolutePath { // Making it a class would be OK too
        private readonly string path; // <<=== It is now private
        public LocalAbsolutePath(string path) {
            this.path = path;
        }
        public static implicit operator string(LocalAbsolutePath p) {
            return p.path;
        }
    }
