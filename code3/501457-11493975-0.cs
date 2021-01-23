    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Media;
    using System.Text;
    
    namespace ConsoleApplication3
    {
        public class SpeechClass
        {
    
            private Dictionary<char, string> _letterToFileMapping = new Dictionary<char, string>();
            private string _basePath = "\\soundfiles";
    
    
            public SpeechClass()
            {
                PopulateMappings();
            }
    
    
            private void PopulateMappings()
            {
                _letterToFileMapping.Add('a', "asound.wav");
                _letterToFileMapping.Add('b', "bsound.wav");
                _letterToFileMapping.Add('c', "csound.wav");
                _letterToFileMapping.Add('d', "dsound.wav");
            }
    
            private void SayWord(string word)
            {
                var chars = word.ToCharArray();
    
                List<string> filestosay = new List<string>();
    
                foreach (var c in chars)
                {
                    string sound;
                    if(_letterToFileMapping.TryGetValue(c, out sound))
                    {
                        filestosay.Add(sound);
                    }
                }
    
                foreach (string s in filestosay)
                {
                    SoundPlayer p = new SoundPlayer();
                    p.SoundLocation = Path.Combine(_basePath, s);
                    p.Play();
    
                }
            }
        }
    }
