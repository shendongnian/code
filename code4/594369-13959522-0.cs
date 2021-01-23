    public partial class Form1 : Form
        {
            private byte[] _leftBuffer;
            private BiQuadFilter _leftFilter;
            private BiQuadFilter _rightFilter;
            public Form1()
            {
                InitializeComponent();
            }
    
            
            private void button1_Click(object sender, EventArgs e)
            {
                openFileDialog1.ShowDialog();
                using (var reader = new Mp3FileReader(openFileDialog1.FileName))
                {
                    var pcmLength = (int)reader.Length;
                    _leftBuffer = new byte[pcmLength / 2];
                    var buffer = new byte[pcmLength];
                    var bytesRead = reader.Read(buffer, 0, pcmLength);
    
                    int index = 0;
                    for (int i = 0; i < bytesRead; i += 4)
                    {
                        _leftBuffer[index] = buffer[i];
                        index++;
                        _leftBuffer[index] = buffer[i + 1];
                        index++;
                    }
                    var player = new WaveLib.WaveOutPlayer(-1, new WaveLib.WaveFormat(44100, 16, 1), _leftBuffer.Length, 1, (data, size) =>
                                                                                                                   {
                                                                                                                       byte[] b = _leftBuffer;
                                                                                                                       System.Runtime.InteropServices.Marshal.Copy(b, 0, data, size);
                                                                                                                   });
                }
            }
        }
