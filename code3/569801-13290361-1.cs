    interface IAudio { void SetVolume(float level); }
    
    class XpAudio : IAudio {
        public void SetVolume(float level) {
            // I do nothing, but this is where your old-style code would go
        }
    }
    class VistaAudio : IAudio {
        public void SetVolume(float level) {
            MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
            MMDevice defaultDevice = devEnum
                .GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
            defaultDevice.AudioEndpointVolume.MasterVolumeLevel = level;
        }
    }
    class Program {
        static void Main(string[] args) {
            IAudio setter = Environment.OSVersion.Version.Major >= 6
                ? (IAudio)new VistaAudio()
                : (IAudio)new XpAudio();
            float val = float.Parse(Console.ReadLine());
            setter.SetVolume(val);
            Console.ReadLine();
        }
    }
