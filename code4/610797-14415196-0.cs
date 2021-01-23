    public class MusicPlayer
    {
        private static Audio m_Audio;
        private static void Loop(Object Sender, EventArgs e)
        {
            ((Audio)Sender).SeekCurrentPosition(0d, SeekPositionFlags.AbsolutePositioning);
        }
        public static void Dispose()
        {
            if (m_Audio != null)
            {
                m_Audio.Stop();
                m_Audio.Dispose();
                m_Audio = null;
            }
        }
        public static void Mute()
        {
            if ((m_Audio != null) && m_Audio.Playing)
                m_Audio.Volume = -10000;
        }
        public static void Play(String filePath, Boolean loop)
        {
            if (File.Exists(filePath))
            {
                Dispose();
                if (m_Audio == null)
                    m_Audio = new Audio(filePath);
                else
                    m_Audio.Open(filePath);
                if (loop)
                    m_Audio.Ending += Loop;
                m_Audio.Volume = MusicSettings.Volume - 10000;
                m_Audio.Play();
            }
        }
        public static void Unmute()
        {
            if (m_Audio != null)
                m_Audio.Volume = MusicSettings.Value - 10000;
        }
    }
