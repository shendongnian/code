    using NAudio.Wave;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        string strPath = Server.MapPath("audio/060.mp3");
        string SongID = "2";
        byte[] bytes = File.ReadAllBytes(strPath);
        WriteToFile(SongID,strPath, bytes);
        Response.Redirect("Main.aspx");
        }
    private void WriteToFile(string SongID, string strPath, byte[] Buffer)
    {
        try
        {
            int samplesPerPixel = 128;
            long startPosition = 0;
            //FileStream newFile = new FileStream(GeneralUtils.Get_SongFilePath() + "/" + strPath, FileMode.Create);
            float[] data = FloatArrayFromByteArray(Buffer);
            Bitmap bmp = new Bitmap(1170, 200);
            int BORDER_WIDTH = 5;
            int width = bmp.Width - (2 * BORDER_WIDTH);
            int height = bmp.Height - (2 * BORDER_WIDTH);
           
            NAudio.Wave.Mp3FileReader reader = new NAudio.Wave.Mp3FileReader(strPath, wf => new NAudio.FileFormats.Mp3.DmoMp3FrameDecompressor(wf));
            NAudio.Wave.WaveChannel32 channelStream = new NAudio.Wave.WaveChannel32(reader);
            int bytesPerSample = (reader.WaveFormat.BitsPerSample / 8) * channelStream.WaveFormat.Channels;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                Pen pen1 = new Pen(Color.Gray);
                int size = data.Length;
                string hexValue1 = "#009adf";
                Color colour1 = System.Drawing.ColorTranslator.FromHtml(hexValue1);
                pen1.Color = colour1;
                Stream wavestream = new NAudio.Wave.Mp3FileReader(strPath, wf => new NAudio.FileFormats.Mp3.DmoMp3FrameDecompressor(wf));
                wavestream.Position = 0;
                int bytesRead1;
                byte[] waveData1 = new byte[samplesPerPixel * bytesPerSample];
                wavestream.Position = startPosition + (width * bytesPerSample * samplesPerPixel);
                for (float x = 0; x < width; x++)
                {
                    short low = 0;
                    short high = 0;
                    bytesRead1 = wavestream.Read(waveData1, 0, samplesPerPixel * bytesPerSample);
                    if (bytesRead1 == 0)
                        break;
                    for (int n = 0; n < bytesRead1; n += 2)
                    {
                        short sample = BitConverter.ToInt16(waveData1, n);
                        if (sample < low) low = sample;
                        if (sample > high) high = sample;
                    }
                    float lowPercent = ((((float)low) - short.MinValue) / ushort.MaxValue);
                    float highPercent = ((((float)high) - short.MinValue) / ushort.MaxValue);
                    float lowValue = height * lowPercent;
                    float highValue = height * highPercent;
                    g.DrawLine(pen1, x, lowValue, x, highValue);
                }
            }
            string filename = Server.MapPath("image/060.png");
            bmp.Save(filename);
            bmp.Dispose();
        }
    catch (Exception e)
        {
            
        }
    }
    public float[] FloatArrayFromStream(System.IO.MemoryStream stream)
    {
        return FloatArrayFromByteArray(stream.GetBuffer());
    }
    public float[] FloatArrayFromByteArray(byte[] input)
    {
        float[] output = new float[input.Length / 4];
        for (int i = 0; i < output.Length; i++)
        {
            output[i] = BitConverter.ToSingle(input, i * 4);
        }
        return output;
    }
    }
