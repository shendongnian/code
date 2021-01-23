    public class AudioManager : IDisposable {
        const int playbackFreq = 44100;
        const int samples = 2048;
        const double pi2 = 360 * Math.PI / 180.0;
        private bool disposed = false;
		private bool initialized = false;
        SdlDotNet.Audio.AudioStream stream;
        byte[] buffer8;
        double time = 0;
        double volume;
        double frequency1 = -1;
        double frequency2 = -1;
        public AudioManager()
        {
            stream = new SdlDotNet.Audio.AudioStream(playbackFreq, 
			                     SdlDotNet.Audio.AudioFormat.Unsigned8, 
			                     SdlDotNet.Audio.SoundChannel.Mono, 
			                     samples, 
			                     new SdlDotNet.Audio.AudioCallback(Callback), 
			                     null);
            buffer8 = new byte[samples];
            volume = 1.0;
            // BUG: OpenAudio (or lower) apparently requires a visible screen for some reason:
            SdlDotNet.Graphics.Video.SetVideoMode(1, 1);
            SdlDotNet.Audio.Mixer.OpenAudio(stream);
            // BUG: close (or hide) it
            SdlDotNet.Graphics.Video.Close();
        }
        public void beep(double duration, double freq) {
            frequency1 = freq;
			frequency2 = -1;
            Tao.Sdl.Sdl.SDL_PauseAudio(0);
            Tao.Sdl.Sdl.SDL_Delay((int)(duration * 1000));
            Tao.Sdl.Sdl.SDL_PauseAudio(1);
        }
		
        void Callback(IntPtr userData, IntPtr stream, int len)
        {
            double slice = 1.0 / playbackFreq * pi2; 
            for (int buf_pos = 0; buf_pos < len; buf_pos++ )
            {
                buffer8[buf_pos] = (byte)(127 + Math.Cos(time) * volume * 127);
                time += frequency1 * slice;
                if (time > pi2)
                    time -= pi2;
            }
            Marshal.Copy(buffer8, 0, stream, len);
        }
