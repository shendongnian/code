    public class MyDocuments
    {
        public DateTime registeredDate;
        public string version;
        public HashSet<Document> registeredDocuments;
        public override bool Equals(Object o)
        {
            if( !(o is MyDocuments) ) return false;
            MyDocuments that = (MyDocuments)o;
            if( !String.Equals(this.version, that.version) ) return false;
            if( this.registeredDocuments.Count != that.registeredDocuments.Count ) return false;
            // assuming registeredDate doesn't matter for equality...
            foreach( Document d in this.registeredDocuments )
                if( !that.registeredDocuments.Contains(d) )
                    return false;
            return true;
        }
        public override int GetHashCode()
        {
            int ret = version.GetHashCode();
            foreach (Document d in this.registeredDocuments)
                ret ^= d.GetHashCode(); // xor isn't great, but better than nothing.
            return ret;
        }
    }
