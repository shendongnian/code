        string Path { get; set; }
    }
    [Serializable()]
    abstract public class NFS : INFS {
        abstract public string Path { get; set; }
        public NFS() {
            Path = "";
            }
        public NFS(string path) {
            Path = path;
            }
        public override bool Equals(object obj) {
            NFS other = obj as NFS;
            return (other != null) && ((IEquatable<NFS>)this).Equals(other);
            }
        bool IEquatable<NFS>.Equals(NFS other) {
            return Path.Equals(other.Path);
            }
        public override int GetHashCode() {
            return Path != null ? Path.GetHashCode() : base.GetHashCode();
            }
        }
