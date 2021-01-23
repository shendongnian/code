    [C#]using Microsoft.DirectX.AudioVideoPlayback;
    public class MyVideoPlayer : System.Windows.Forms.Form
    {
        /* ... */
        private void OpenFile()
        {
            try
            {
                Video ourVideo = new Video("C:\\Example.avi");
                /* ... */
            }
        }
        /* ... */
    }
