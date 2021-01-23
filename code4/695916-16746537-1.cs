    class Ffmpeg
    {
        NamedPipeServerStream p;
        String pipename = "mytestpipe";
        byte[] b;
        //int i, j;
        System.Diagnostics.Process process;
        IAsyncResult ar;
        public Ffmpeg()
        {
        }
        public void Start(string FileName, int BitmapRate )
        {
            p = new NamedPipeServerStream(pipename, PipeDirection.Out, 1, PipeTransmissionMode.Byte);
            b = new byte[1920 * 1080 * 3]; // some buffer for the r g and b of pixels of an image of size 720p 
            process = new System.Diagnostics.Process();
            process.StartInfo.FileName = @"D:\pipetest\pipetest\ffmpegx86\ffmpeg.exe";
            process.EnableRaisingEvents = false;
            process.StartInfo.WorkingDirectory = @"D:\pipetest\pipetest\ffmpegx86";
            process.StartInfo.Arguments = @"-f rawvideo -pix_fmt bgr0 -video_size 1920x1080 -i \\.\pipe\mytestpipe -map 0 -c:v libx264 -r " + BitmapRate + " " + FileName;
            process.Start();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = false;
            ar = p.BeginWaitForConnection(EndWait, null);
        }
    //callback when client connects
    void EndWait(IAsyncResult iar){
        var state = iar.AsyncState; // fetch state -> cast to desired type
        //do something when client connected
    }
