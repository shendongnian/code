    public class AudioFileValidator
    {
        private List<string> _extensions = new List<string>{".aac", ".mp3"};
        public bool IsValid(string filename)
        {
            if (!_extensions.Contains(Path.GetExtension(filename))
                return false;
                
            //validate bitrate etc
        }
    }
