    [XmlRoot("RegexTesterPersistantSettings")]
    [Serializable]
    public class State
    {
        public State()
        {
            this.Pattern = string.Empty;
            this.TestString = string.Empty;
            this.Options = 0;
        }
        [XmlElement("Pattern")]
        public string Pattern{get;set;}
        [XmlElement("TestString")]
        public string TestString{get;set;}
        [XmlElement("Options")]
        public int Options { get; set; }
        public override int GetHashCode()
        {
            return this.Options.GetHashCode() ^ this.Pattern.GetHashCode() ^ this.TestString.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            State anotherState = obj as State;
            if (anotherState == null)
            {
                return false;
            }
            return this.Equals(anotherState);
        }
        public bool Equals(State anotherState)
        {
            return this.GetHashCode() == anotherState.GetHashCode();
        }
        public static bool operator ==(State a, State b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            return a.Equals(b);
        }
        public static bool operator !=(State a, State b)
        {
            return !a.Equals(b);
        }
    }
    public class PersistantHelper
    {
        private string filename;
        private State _state;
        public PersistantHelper(string xmlFilename = "RegexTesterSettings")
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            this.filename  = Path.Combine(appDataPath, xmlFilename);
        }
        private XmlSerializer _serializer;
        private XmlSerializer Serializer
        {
            get
            {
                if (this._serializer == null)
                {
                    this._serializer = new XmlSerializer(typeof(State));
                }
                return this._serializer;
            }
        }
        private void SaveState(State state)
        {
            if (File.Exists(this.filename))
            {
                File.Delete(this.filename);
            }
            var stream  = new FileStream(this.filename,  FileMode.OpenOrCreate, FileAccess.Write,FileShare.None);
            this.Serializer.Serialize(stream, state);
            stream.Close();
        }
        public State State
        {
            get
            {
                if (this._state == null)
                {
                    this._state = this.GetState();
                }
                return this._state;
            }
            set 
            {
                if (this.State != value)
                {
                    this.SaveState(value);
                }
            }
        }
        private State dummyState = new State() { Options = 0 };
        private State GetState()
        {
            if (!File.Exists(this.filename))
            {
                return this.dummyState;
            }
            Stream stream = null;
            try
            {
                stream = new FileStream(this.filename, FileMode.Open, FileAccess.Read,FileShare.None);
                var o = this.Serializer.Deserialize(stream);
                return (State)o;
            }
            catch
            {
                return this.dummyState;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            
        }
    }
